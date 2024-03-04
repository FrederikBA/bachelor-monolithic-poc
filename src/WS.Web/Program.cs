using Microsoft.EntityFrameworkCore;
using WS.Core.Interfaces.AggregateServices;
using WS.Core.Interfaces.DomainServices;
using WS.Core.Interfaces.Repositories;
using WS.Core.Services;
using WS.Infrastructure.Data;
using WS.Web.Interfaces;
using WS.Web.Services;

var builder = WebApplication.CreateBuilder(args);

//CORS
const string policyName = "AllowOrigin";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

//DBContext
builder.Services.AddDbContext<ChemicalContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbContext"));
});

//API Controllers
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Build repositories
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfReadRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));


//Build services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IWarningSentenceService, WarningSentenceService>();
builder.Services.AddScoped<IWarningSentenceAggregateService, WarningSentenceAggregateService>();

builder.Services.AddScoped<IProductViewModelService, ProductViewModelService>();
builder.Services.AddScoped<IWarningSentenceViewModelService, WarningSentenceViewModelService>();
builder.Services.AddScoped<IWarningSentenceModalService, WarningSentenceModalService>();

var app = builder.Build();

app.UseStaticFiles(); //For wwwroot frontend build
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors(policyName);
app.UseHttpsRedirection();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();