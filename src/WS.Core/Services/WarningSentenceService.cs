using WS.Core.Entities.WSAggregate;
using WS.Core.Interfaces.DomainServices;

namespace WS.Core.Services;

public class WarningSentenceService : IWarningSentenceService
{
    public Task<List<WarningSentence>> GetAllWarningSentencesAsync()
    {
        throw new NotImplementedException();
    }
}