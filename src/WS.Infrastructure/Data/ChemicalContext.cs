using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WS.Core.Entities.ChemicalAggregate;
using WS.Core.Entities.WSAggregate;

namespace WS.Infrastructure.Data;

public class ChemicalContext : DbContext
{
    //Product Aggregate
    public DbSet<Product>? Products { get; set; }
    public DbSet<ProductCategory>? ProductCategories { get; set; }
    public DbSet<ProductGroup>? ProductGroups { get; set; }
    public DbSet<Producer>? Producers { get; set; }
    
    //WarningSentence Aggregate
    public DbSet<WarningSentence>? WarningSentences { get; set; }
    public DbSet<WarningCategory>? WarningCategories { get; set; }
    public DbSet<WarningType>? WarningTypes { get; set; }
    public DbSet<WarningSignalWord>? WarningSignalWords { get; set; }
    public DbSet<WarningPictogram>? WarningPictograms { get; set; }
    
    public ChemicalContext(DbContextOptions<ChemicalContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Primary keys
        modelBuilder.Entity<Product>().HasKey(product => product.Id);
        modelBuilder.Entity<ProductCategory>().HasKey(productCategory => productCategory.Id);
        modelBuilder.Entity<ProductGroup>().HasKey(productGroup => productGroup.Id);
        modelBuilder.Entity<Producer>().HasKey(producer => producer.Id);
        modelBuilder.Entity<ProductStatus>().HasKey(productStatus => productStatus.Id);
        
        modelBuilder.Entity<WarningSentence>().HasKey(warningSentence => warningSentence.Id);
        modelBuilder.Entity<WarningCategory>().HasKey(warningCategory => warningCategory.Id);
        modelBuilder.Entity<WarningType>().HasKey(warningType => warningType.Id);
        modelBuilder.Entity<WarningSignalWord>().HasKey(warningSignalWord => warningSignalWord.Id);
        modelBuilder.Entity<WarningPictogram>().HasKey(warningPictogram => warningPictogram.Id);
        
        //Add Value Objects
        modelBuilder.Entity<ProducerAddress>(ConfigureAddress);
        
        //Relationships
        
        //Product to ProductCategory (one to one)
        modelBuilder.Entity<Product>()
            .HasOne(product => product.ProductCategory)
            .WithOne(productCategory => productCategory.Product)
            .HasForeignKey<Product>(productCategory => productCategory.Id);

        
        //ProductCategory to ProductGroup (many to one)
        modelBuilder.Entity<ProductCategory>()
            .HasOne(productCategory => productCategory.ProductGroup)
            .WithMany(productGroup => productGroup.ProductCategories)
            .HasForeignKey(p => p.ProductGroupId);
        
        //Product to Producer (many to one)
        modelBuilder.Entity<Product>()
            .HasOne(product => product.Producer)
            .WithMany(producer => producer.Products)
            .HasForeignKey(p => p.ProducerId);
        
        //Product to ProductStatus (many to one)
        modelBuilder.Entity<Product>()
            .HasOne(product => product.ProductStatus)
            .WithMany(productStatus => productStatus.Products)
            .HasForeignKey(p => p.ProductStatusId);
        
        //Product to WarningSentence (many to many)
        modelBuilder.Entity<Product>()
            .HasMany(product => product.WarningSentences)
            .WithMany(warningSentence => warningSentence.Products)
            .UsingEntity(j => j.ToTable("ProductWarningSentences"));
        
        //WarningSentence to WarningCategory (one to many)
        modelBuilder.Entity<WarningSentence>()
            .HasOne(warningSentence => warningSentence.WarningCategory)
            .WithMany(warningCategory => warningCategory.WarningSentences)
            .HasForeignKey(w => w.WarningCategoryId);
        
        //WarningSentence to WarningSignalWord (one to many)
        modelBuilder.Entity<WarningSentence>()
            .HasOne(warningSentence => warningSentence.WarningSignalWordd)
            .WithMany(warningSignalWord => warningSignalWord.WarningSentences)
            .HasForeignKey(w => w.WarningSignalWordId);
        
        //WarningSentence to WarningPictogram (one to many)
        modelBuilder.Entity<WarningSentence>()
            .HasOne(warningSentence => warningSentence.WarningPictogram)
            .WithMany(warningPictogram => warningPictogram.WarningSentences)
            .HasForeignKey(w => w.WarningPictogramId);
        
        //WarningCategory to WarningType (one to many)
        modelBuilder.Entity<WarningCategory>()
            .HasOne(warningCategory => warningCategory.WarningType)
            .WithMany(warningType => warningType.WarningCategories)
            .HasForeignKey(w => w.WarningTypeId);
    }
    
    //Address value object
    void ConfigureAddress<T>(EntityTypeBuilder<T> entity) where T : ProducerAddress
    {
        entity.ToTable("ProducerAddress", "dbo");

        entity.Property<int>("Id")
            .IsRequired();
        entity.HasKey("Id");
    }
}