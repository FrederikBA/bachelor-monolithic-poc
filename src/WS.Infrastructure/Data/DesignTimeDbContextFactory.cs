using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WS.Infrastructure.Data;

namespace Orders.Infrastructure.Data;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ChemicalContext>
{
    public ChemicalContext CreateDbContext(string[] args)
    {
        //TODO: Move connection string to appsettings.json / configuration file
        const string connectionString = "Server=localhost;Database=KemiDB;User Id=sa;Password=thisIsSuperStrong1234;TrustServerCertificate=True";
        
        var optionsBuilder = new DbContextOptionsBuilder<ChemicalContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new ChemicalContext(optionsBuilder.Options);
    }
}