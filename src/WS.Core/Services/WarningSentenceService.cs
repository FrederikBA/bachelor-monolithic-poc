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

    public WarningSentenceService(IReadRepository<WarningSentence> warningSentenceReadRepository,
        IRepository<WarningSentence> warningSentenceRepository)
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
        var warningSentence =
            await _warningSentenceReadRepository.FirstOrDefaultAsync(new GetWarningSentenceByIdFullSpec(id));

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

    public async Task<WarningSentence> RenameWarningSentenceAsync(int id, string renameTo)
    {
        //Get the warning sentence that needs to be renamed
        var warningSentence = await _warningSentenceReadRepository.GetByIdAsync(id);

        if (warningSentence == null)
        {
            throw new WarningSentenceNotFoundException(id);
        }
        
        //Rename the warning sentence
        warningSentence.Code = renameTo;
        
        await _warningSentenceRepository.UpdateAsync(warningSentence);
        
        return warningSentence;
    }

    public async Task<bool> DeleteWarningSentenceAsync(int id)
    {
        //Get the warning sentence that needs to be deleted
        var warningSentence = await _warningSentenceReadRepository.FirstOrDefaultAsync(new WarningSentenceWithProductsSpec(id));
        
        //Check if null
        if (warningSentence == null)
        {
            throw new WarningSentenceNotFoundException(id);
        }
        
        //Check if the warning sentence is in use
        if (warningSentence.Products!.Count > 0)
        {
            throw new WarningSentenceInUseException(warningSentence.Products.Select(p => p.Id).ToList());
        }
        
        //Delete the warning sentence
        await _warningSentenceRepository.DeleteAsync(warningSentence);
        
        return true;
    }
}