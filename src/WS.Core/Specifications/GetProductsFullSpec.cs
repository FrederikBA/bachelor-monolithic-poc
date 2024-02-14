using Ardalis.Specification;
using WS.Core.Entities.ChemicalAggregate;

namespace WS.Core.Specifications;

public sealed class GetProductsFullSpec : Specification<Product>
{
    public GetProductsFullSpec()
    {
        Query.Include(product => product.ProductCategory);
    }
}