using WS.Core.Interfaces.DomainServices;
using WS.Web.Interfaces;
using WS.Web.ViewModels;

namespace WS.Web.Services;

public class ProductViewModelService : IProductViewModelService
{
    private readonly IProductService _productService;

    public ProductViewModelService(IProductService productService)
    {
        _productService = productService;
    }


    public async Task<List<ProductViewModel>> GetProductViewModelsAsync()
    {
        var productEntities = await _productService.GetAllProductsAsync();
        
        var productViewModels = productEntities.Select(product => new ProductViewModel
        {
            Name = product.Name,
            Category = new ProductCategoryViewModel
            {
                Category = product.ProductCategory?.Category
            }
        }).ToList();
        
        return productViewModels;
    }
}