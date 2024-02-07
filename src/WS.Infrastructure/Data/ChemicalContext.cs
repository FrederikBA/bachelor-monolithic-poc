using Microsoft.EntityFrameworkCore;
using WS.Core.Entities.ChemicalAggregate;

namespace WS.Infrastructure.Data;

public class ChemicalContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    
    public ChemicalContext(DbContextOptions<ChemicalContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Primary keys
        modelBuilder.Entity<Product>().HasKey(p => p.Id);
        modelBuilder.Entity<ProductCategory>().HasKey(p => p.Id);
        modelBuilder.Entity<ProductGroup>().HasKey(p => p.Id);
        
        //Relationships
        
        //Product to ProductCategory (one to many)
        modelBuilder.Entity<Product>()
            .HasOne(product => product.ProductCategory)
            .WithMany()
            .HasForeignKey(p => p.ProductCategoryId);
        
        //ProductCategory to ProductGroup (many to one)
        modelBuilder.Entity<ProductCategory>()
            .HasOne(productCategory => productCategory.ProductGroup)
            .WithMany(productGroup => productGroup.ProductCategories)
            .HasForeignKey(p => p.ProductGroupId);
    }
}