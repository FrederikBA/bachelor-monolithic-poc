using Ardalis.Specification.EntityFrameworkCore;
using WS.Core.Interfaces.Repositories;

namespace WS.Infrastructure.Data;

public class EfReadRepository<T> : RepositoryBase<T>, IReadRepository<T> where T : class
{
    public readonly ChemicalContext ChemicalContext;
    
    public EfReadRepository(ChemicalContext dbContext) : base(dbContext)
    {
        ChemicalContext = dbContext;
    }
}