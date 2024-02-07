namespace WS.Core.Entities.ChemicalAggregate;

public class ProductGroup : BaseEntity
{
    public string? GroupName { get; set; }
    public List<ProductCategory>? ProductCategories { get; set; }
}