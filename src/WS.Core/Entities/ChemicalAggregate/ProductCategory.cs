namespace WS.Core.Entities.ChemicalAggregate;

public class ProductCategory : BaseEntity
{
    public int ProductGroupId { get; set; }
    public string? Category { get; set; }
    public Product? Product { get; set; }
    public ProductGroup? ProductGroup { get; set; }
}