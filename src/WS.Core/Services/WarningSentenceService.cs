using WS.Core.Entities.WSAggregate;
using WS.Core.Exceptions;
using WS.Core.Interfaces.DomainServices;
using WS.Core.Interfaces.Repositories;
using WS.Core.Specifications;

namespace WS.Core.Services;

public class WarningSentenceService : IWarningSentenceService
{
    private readonly IReadRepository<WarningSentence> _warningSentenceReadRepository;

    public WarningSentenceService(IReadRepository<WarningSentence> warningSentenceReadRepository)
    {
        _warningSentenceReadRepository = warningSentenceReadRepository;
    }

    public async Task<List<WarningSentence>> GetAllWarningSentencesAsync()
    {
        var warningSentences = await _warningSentenceReadRepository.ListAsync(new GetWarningSentencesFullSpec());
        
        if (warningSentences == null || warningSentences.Count == 0)
        {
            throw new WarningSentencesNotFoundException();
        }
        
        return warningSentences;
    }
}