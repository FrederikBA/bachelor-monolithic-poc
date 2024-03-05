using WS.Core.Entities.WSAggregate;
using WS.Core.Models.Dtos;

namespace WS.Core.Interfaces.DomainServices;

public interface IWarningSentenceService
{
    Task<List<WarningSentence>> GetAllWarningSentencesAsync();
    Task<WarningSentence> GetWarningSentenceByIdAsync(int id);
    Task<WarningSentence> GetWarningSentenceBaseByIdAsync(int id);
    Task<WarningSentence> AddWarningSentenceAsync(WarningSentenceDto warningSentenceDto);
    Task<IEnumerable<WarningSentence>> CloneWarningSentenceAsync(List<int> ids);
    Task<WarningSentence> RenameWarningSentenceAsync(int id, string renameTo);
    Task<bool> DeleteWarningSentenceAsync(List<int> ids);
    Task<WarningSentence> UpdateWarningSentenceAsync(int id, WarningSentenceDto warningSentenceDto);
}