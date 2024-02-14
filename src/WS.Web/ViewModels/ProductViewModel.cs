namespace WS.Web.ViewModels;

public class ProductViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public ProductCategoryViewModel? Category { get; set; }
}