using WS.Core.Entities.ChemicalAggregate;
using WS.Core.Interfaces.DomainServices;
using WS.Core.Interfaces.Repositories;

namespace WS.Core.Services;

public class ProductService : IProductService
{
    private readonly IReadRepository<Product> _productReadRepository;

    public ProductService(IReadRepository<Product> productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public Task<List<Product>> GetAllProductsAsync()
    {
        throw new NotImplementedException();
    }
}