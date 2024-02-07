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
        modelBuilder.Entity<Product>().HasKey(product => product.Id);
        modelBuilder.Entity<ProductCategory>().HasKey(productCategory => productCategory.Id);
        modelBuilder.Entity<ProductGroup>().HasKey(productGroup => productGroup.Id);
        
        //Relationships
        
        //Product to ProductCategory (one to one)
        modelBuilder.Entity<ProductCategory>()
            .HasOne(productCategory => productCategory.Product)
            .WithOne(product => product.ProductCategory)
            .HasForeignKey<ProductCategory>(product => product.Id);

        
        //ProductCategory to ProductGroup (many to one)
        modelBuilder.Entity<ProductCategory>()
            .HasOne(productCategory => productCategory.ProductGroup)
            .WithMany(productGroup => productGroup.ProductCategories)
            .HasForeignKey(p => p.ProductGroupId);
    }
}