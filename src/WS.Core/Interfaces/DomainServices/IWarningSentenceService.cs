using WS.Core.Entities.WSAggregate;
using WS.Core.Models.Dtos;

namespace WS.Core.Interfaces.DomainServices;

public interface IWarningSentenceService
{
    Task<List<WarningSentence>> GetAllWarningSentencesAsync();
    Task<WarningSentence> GetWarningSentenceByIdAsync(int id);
    Task<WarningSentence> AddWarningSentenceAsync(WarningSentenceDto warningSentenceDto);
    Task<WarningSentence> CloneWarningSentenceAsync(int id);
    Task<WarningSentence> RenameWarningSentenceAsync(int id, string renameTo);
    Task<bool> DeleteWarningSentenceAsync(List<int> ids);
}