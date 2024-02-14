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
            Id = product.Id,
            Name = product.Name,
            Category = new ProductCategoryViewModel
            {
                Id = product.ProductCategory?.Id ?? 0,
                Category = product.ProductCategory?.Category,
                ProductGroup = new ProductGroupViewModel
                {
                    Id = product.ProductCategory?.ProductGroup?.Id ?? 0,
                    GroupName = product.ProductCategory?.ProductGroup?.GroupName,
                    Remarks = product.ProductCategory?.ProductGroup?.Remarks
                }
            }
        }).ToList();
        
        return productViewModels;
    }
}