using Ardalis.Specification.EntityFrameworkCore;
using WS.Core.Interfaces;
using WS.Core.Interfaces.Repositories;

namespace WS.Infrastructure.Data;

public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public readonly ChemicalContext ChemicalContext;
    
    public EfRepository(ChemicalContext dbContext) : base(dbContext)
    {
        ChemicalContext = dbContext;
    }
}