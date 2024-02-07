namespace WS.Core.Entities.ChemicalAggregate;

public class ProductGroup : BaseEntity
{
    public List<ProductCategory> ProductCategories { get; set; }
}