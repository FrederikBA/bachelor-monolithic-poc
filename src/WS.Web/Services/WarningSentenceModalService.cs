using WS.Core.Interfaces.AggregateServices;
using WS.Core.Interfaces.DomainServices;
using WS.Web.Interfaces;
using WS.Web.ViewModels.WarningSentence;
using WS.Web.ViewModels.WarningSentence.CreateForm;

namespace WS.Web.Services;

public class WarningSentenceModalService : IWarningSentenceModalService
{
    private readonly IWarningSentenceService _warningSentenceService;
    private readonly IWarningSentenceAggregateService _warningSentenceAggregateService;

    public WarningSentenceModalService(IWarningSentenceService warningSentenceService, IWarningSentenceAggregateService warningSentenceAggregateService)
    {
        _warningSentenceService = warningSentenceService;
        _warningSentenceAggregateService = warningSentenceAggregateService;
    }

    public async Task<WarningSentenceBaseViewModel> GetWarningSentenceModalAsync(int id)
    {
        var warningSentence = await _warningSentenceService.GetWarningSentenceBaseByIdAsync(id);

        return new WarningSentenceBaseViewModel
        {
            Id = warningSentence.Id,
            Code = warningSentence.Code
        };
    }

    public async Task<List<WarningSentenceBaseViewModel>> GetWarningSentencesModalAsync(List<int> ids)
    {
        var warningSentences = new List<WarningSentenceBaseViewModel>();

        foreach (var id in ids)
        {
            var warningSentence = await GetWarningSentenceModalAsync(id);

            warningSentences.Add(warningSentence);
        }

        return warningSentences;
    }

    public async Task<WarningSentenceFormViewModel> GetCreateFormModalAsync()
    {
        var warningCategories = await _warningSentenceAggregateService.GetAllWarningCategoriesAsync();
        var warningPictograms = await _warningSentenceAggregateService.GetAllWarningPictogramsAsync();
        var warningSignalWords = await _warningSentenceAggregateService.GetAllWarningSignalWordsAsync();
        
        return new WarningSentenceFormViewModel
        {
            WarningCategories = warningCategories.Select(warningCategory => new WarningCategoryFormViewModel
            {
                Id = warningCategory.Id,
                Text = warningCategory.Text
            }).ToList(),
            WarningPictograms = warningPictograms.Select(warningPictogram => new WarningPictogramFormViewModel
            {
                Id = warningPictogram.Id,
                Code = warningPictogram.Code,
                Text = warningPictogram.Text,
                Pictogram = warningPictogram.Pictogram,
                Extension = warningPictogram.Extension
            }).ToList(),
            WarningSignalWords = warningSignalWords.Select(warningSignalWord => new WarningSignalWordFormViewModel
            {
                Id = warningSignalWord.Id,
                SignalWordText = warningSignalWord.SignalWordText
            }).ToList()
        };
    }
}