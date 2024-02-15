using WS.Core.Entities.ChemicalAggregate;
using WS.Core.Exceptions;
using WS.Core.Interfaces.DomainServices;
using WS.Core.Interfaces.Repositories;
using WS.Core.Specifications;

namespace WS.Core.Services;

public class ProductService : IProductService
{
    private readonly IReadRepository<Product> _productReadRepository;

    public ProductService(IReadRepository<Product> productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var products = await _productReadRepository.ListAsync(new GetProductsFullSpec());
        
        if (products == null || products.Count == 0)
        {
            throw new ProductsNotFoundException();
        }
        
        return products;
    }
}