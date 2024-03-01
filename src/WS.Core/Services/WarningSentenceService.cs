using WS.Core.Entities.WSAggregate;
using WS.Core.Exceptions;
using WS.Core.Interfaces.DomainServices;
using WS.Core.Interfaces.Repositories;
using WS.Core.Models.Dtos;
using WS.Core.Specifications;

namespace WS.Core.Services;

public class WarningSentenceService : IWarningSentenceService
{
    private readonly IReadRepository<WarningSentence> _warningSentenceReadRepository;
    private readonly IRepository<WarningSentence> _warningSentenceRepository;

    public WarningSentenceService(IReadRepository<WarningSentence> warningSentenceReadRepository, IRepository<WarningSentence> warningSentenceRepository)
    {
        _warningSentenceReadRepository = warningSentenceReadRepository;
        _warningSentenceRepository = warningSentenceRepository;
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

    public async Task<WarningSentence> GetWarningSentenceByIdAsync(int id)
    {
        var warningSentence = await _warningSentenceReadRepository.FirstOrDefaultAsync(new GetWarningSentenceByIdFullSpec(id));
        
        if (warningSentence == null)
        {
            throw new WarningSentenceNotFoundException(id);
        }

        return warningSentence;
    }

    public Task<WarningSentence> AddWarningSentenceAsync(WarningSentenceDto warningSentenceDto)
    {
        var warningSentence = new WarningSentence
        {
            Code = warningSentenceDto.Code,
            Text = warningSentenceDto.Text,
            WarningCategoryId = warningSentenceDto.WarningCategoryId,
            WarningSignalWordId = warningSentenceDto.WarningSignalWordId,
            WarningPictogramId = warningSentenceDto.WarningPictogramId
        };
        
        return _warningSentenceRepository.AddAsync(warningSentence);
    }

    public async Task<WarningSentence> CloneWarningSentenceAsync(int id)
    {
        //Get the warning sentence that needs to be cloned
        var warningSentence = await _warningSentenceReadRepository.GetByIdAsync(id);
        
        if (warningSentence == null)
        {
            throw new WarningSentenceNotFoundException(id);
        }
        
        //Clone the warning sentence
        var clonedWarningSentence = new WarningSentence
        {
            Code = warningSentence.Code + " (Copy)",
            Text = warningSentence.Text,
            WarningCategoryId = warningSentence.WarningCategoryId,
            WarningSignalWordId = warningSentence.WarningSignalWordId,
            WarningPictogramId = warningSentence.WarningPictogramId
        };
        
        return await _warningSentenceRepository.AddAsync(clonedWarningSentence);
    }

    public Task<WarningSentence> RenameWarningSentenceAsync(int id, string renameTo)
    {
        throw new NotImplementedException();
    }
}