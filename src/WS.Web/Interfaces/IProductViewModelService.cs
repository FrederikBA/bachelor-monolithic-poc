using WS.Web.ViewModels;
using WS.Web.ViewModels.Product;

namespace WS.Web.Interfaces;

public interface IProductViewModelService
{
    public Task<List<ProductViewModel>> GetProductViewModelsAsync();
    public Task<ProductViewModel> GetProductViewModelAsync(int id);
}