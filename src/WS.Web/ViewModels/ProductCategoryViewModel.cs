namespace WS.Web.ViewModels;

public class ProductCategoryViewModel
{
    public int Id { get; set; }
    public string? Category { get; set; }
    public ProductGroupViewModel? ProductGroup { get; set; }
}