using WS.Core.Interfaces.AggregateServices;
using WS.Core.Interfaces.DomainServices;
using WS.Web.Interfaces;
using WS.Web.ViewModels.WarningSentence;
using WS.Web.ViewModels.WarningSentence.Form;

namespace WS.Web.Services;
 
public class WarningSentenceModalService : IWarningSentenceModalService
{
    private readonly IWarningSentenceService _warningSentenceService;
    private readonly IWarningSentenceAggregateService _warningSentenceAggregateService;
    private readonly IWarningSentenceViewModelService _warningSentenceViewModelService;

    public WarningSentenceModalService(IWarningSentenceService warningSentenceService, IWarningSentenceAggregateService warningSentenceAggregateService, IWarningSentenceViewModelService warningSentenceViewModelService)
    {
        _warningSentenceService = warningSentenceService;
        _warningSentenceAggregateService = warningSentenceAggregateService;
        _warningSentenceViewModelService = warningSentenceViewModelService;
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

    public async Task<WarningSentenceEditFormViewModel> GetEditFormModalAsync(int id)
    {
        //Get the warning sentence form data (to choose from)
        var warningCategories = await _warningSentenceAggregateService.GetAllWarningCategoriesAsync();
        var warningPictograms = await _warningSentenceAggregateService.GetAllWarningPictogramsAsync();
        var warningSignalWords = await _warningSentenceAggregateService.GetAllWarningSignalWordsAsync();
        
        //Map to form view models

        var viewModel = new WarningSentenceEditFormViewModel
        {
            //Get the warning sentence to edit to fill in the form
            WarningSentence = await _warningSentenceViewModelService.GetWarningSentenceViewModel(id),
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
        return viewModel;
    }
}