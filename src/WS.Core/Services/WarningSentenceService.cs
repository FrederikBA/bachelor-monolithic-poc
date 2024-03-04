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
    
    public Task<WarningSentence> GetWarningSentenceBaseByIdAsync(int id)
    {
        throw new NotImplementedException();
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

    public async Task<IEnumerable<WarningSentence>> CloneWarningSentenceAsync(List<int> ids)
    {
        //Get the warning sentence that needs to be cloned
        var warningSentences = await _warningSentenceReadRepository.ListAsync();

        //Filter the warning sentences that needs to be cloned (ids)
        warningSentences = warningSentences.Where(w => ids.Contains(w.Id)).ToList();

        if (warningSentences == null || warningSentences.Count == 0)
        {
            throw new WarningSentencesNotFoundException();
        }
        
        var clonedWarningSentences = new List<WarningSentence>();

        foreach (var warningSentence in warningSentences)
        {
            //Clone the warning sentence
            var clonedWarningSentence = new WarningSentence
            {
                Code = warningSentence.Code + " (Copy)",
                Text = warningSentence.Text,
                WarningCategoryId = warningSentence.WarningCategoryId,
                WarningSignalWordId = warningSentence.WarningSignalWordId,
                WarningPictogramId = warningSentence.WarningPictogramId
            };
            
            //Add the cloned warning sentence to the list
            clonedWarningSentences.Add(clonedWarningSentence);
        }


        return await _warningSentenceRepository.AddRangeAsync(clonedWarningSentences);
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

    public async Task<bool> DeleteWarningSentenceAsync(List<int> ids)
    {
        //Get the warning sentences that needs to be deleted

        var warningSentences = new List<WarningSentence>();

        foreach (var warningSentenceId in ids)
        {
            var warningSentence =
                await _warningSentenceReadRepository.FirstOrDefaultAsync(
                    new WarningSentenceWithProductsSpec(warningSentenceId));

            //Check if null
            if (warningSentence == null)
            {
                throw new WarningSentenceNotFoundException(warningSentenceId);
            }

            //Check if the warning sentence is in use
            if (warningSentence.Products!.Count > 0)
            {
                throw new WarningSentenceInUseException(warningSentence.Products.Select(p => p.Id).ToList());
            }

            warningSentences.Add(warningSentence);
        }

        //Delete the warning sentence
        await _warningSentenceRepository.DeleteRangeAsync(warningSentences);

        return true;
    }
}