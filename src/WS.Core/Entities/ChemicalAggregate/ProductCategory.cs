namespace WS.Core.Entities.ChemicalAggregate;

public class ProductCategory : BaseEntity
{
    public int ProductGroupId { get; set; }
    public Product? Product { get; set; }
    public string? Category { get; set; }
    public string? Remarks { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
}