using Ardalis.Specification;
using WS.Core.Entities.ChemicalAggregate;

namespace WS.Core.Specifications;

public sealed class GetProductsFullSpec : Specification<Product>
{
    public GetProductsFullSpec()
    {
        Query
            .Include(product => product.Producer)
            .ThenInclude(producer => producer!.Address)
            .Include(product => product.ProductStatus)
            .Include(product => product.ProductCategory)
            .ThenInclude(category => category!.ProductGroup);
    }
}