using WS.Core.Entities.WSAggregate;
using WS.Core.Interfaces.AggregateServices;
using WS.Core.Interfaces.Repositories;

namespace WS.Core.Services;

public class WarningSentenceAggregateService : IWarningSentenceAggregateService
{
    private readonly IReadRepository<WarningCategory> _warningCategoryReadRepository;
    private readonly IReadRepository<WarningPictogram> _warningPictogramReadRepository;
    private readonly IReadRepository<WarningSignalWord> _warningSignalWordReadRepository;

    public WarningSentenceAggregateService(IReadRepository<WarningCategory> warningCategoryReadRepository, IReadRepository<WarningPictogram> warningPictogramReadRepository, IReadRepository<WarningSignalWord> warningSignalWordReadRepository)
    {
        _warningCategoryReadRepository = warningCategoryReadRepository;
        _warningPictogramReadRepository = warningPictogramReadRepository;
        _warningSignalWordReadRepository = warningSignalWordReadRepository;
    }

    public async Task<List<WarningCategory>> GetAllWarningCategoriesAsync()
    {
        var categories = await _warningCategoryReadRepository.ListAsync();
        return categories;
    }

    public async Task<List<WarningPictogram>> GetAllWarningPictogramsAsync()
    {
        var pictograms = await _warningPictogramReadRepository.ListAsync();
        return pictograms;
    }

    public Task<List<WarningSignalWord>> GetAllWarningSignalWordsAsync()
    {
        var signalWords = _warningSignalWordReadRepository.ListAsync();
        return signalWords;
    }
}