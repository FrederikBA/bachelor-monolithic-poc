using Ardalis.Specification;
using WS.Core.Entities.WSAggregate;

namespace WS.Core.Specifications;

public sealed class WarningSentenceWithProductsSpec : Specification<WarningSentence>
{
    public WarningSentenceWithProductsSpec(int warningSentenceId)
    {
        Query
            .Where(w => w.Id == warningSentenceId)
            .Include(w => w.Products);
    }
}