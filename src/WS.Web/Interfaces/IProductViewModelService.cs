using WS.Web.ViewModels;

namespace WS.Web.Interfaces;

public interface IProductViewModelService
{
    public Task<List<ProductViewModel>> GetProductViewModelsAsync();
}