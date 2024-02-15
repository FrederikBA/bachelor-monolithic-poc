using WS.Core.Entities.ChemicalAggregate;

namespace WS.Core.Interfaces.DomainServices;

public interface IProductService
{
    Task<List<Product>> GetAllProductsAsync();
    Task<Product> GetProductByIdAsync(int id);
}