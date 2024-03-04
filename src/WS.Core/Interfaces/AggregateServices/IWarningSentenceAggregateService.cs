using WS.Core.Entities.WSAggregate;

namespace WS.Core.Interfaces.AggregateServices;

public interface IWarningSentenceAggregateService
{
    Task<List<WarningCategory>> GetAllWarningCategoriesAsync();
    Task<List<WarningPictogram>> GetAllWarningPictogramsAsync();
    Task<List<WarningSignalWord>> GetAllWarningSignalWordsAsync();
}