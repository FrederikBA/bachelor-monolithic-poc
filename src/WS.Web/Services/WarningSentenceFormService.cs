using Microsoft.AspNetCore.Mvc.Rendering;
using WS.Core.Entities.WSAggregate;
using WS.Core.Interfaces.Repositories;
using WS.Web.Interfaces;
using WS.Web.ViewModels.WarningSentence.CreateForm;

namespace WS.Web.Services;

public class WarningSentenceFormService : IWarningSentenceFormService
{
    private readonly IReadRepository<WarningCategory> _categoryRepository;
    private readonly IReadRepository<WarningPictogram> _pictogramRepository;
    private readonly IReadRepository<WarningSignalWord> _signalWordRepository;

    public WarningSentenceFormService(IReadRepository<WarningCategory> categoryRepository, IReadRepository<WarningPictogram> pictogramRepository, IReadRepository<WarningSignalWord> signalWordRepository)
    {
        _categoryRepository = categoryRepository;
        _pictogramRepository = pictogramRepository;
        _signalWordRepository = signalWordRepository;
    }

    public async Task<WarningSentenceFormViewModel> GetWarningSentenceCreateFormAsync(int id)
    {
        var warningCategories = await _categoryRepository.ListAsync();
        var warningPictograms = await _pictogramRepository.ListAsync();
        var warningSignalWords = await _signalWordRepository.ListAsync();
        
        var viewModel = new WarningSentenceFormViewModel
        {
            WarningCategories = warningCategories.Select(x => new WarningCategoryFormViewModel{Id = x.Id, Text = x.Text}).ToList(),
            WarningPictograms = warningPictograms.Select(x => new WarningPictogramFormViewModel{Id = x.Id, Text = x.Text}).ToList(),
            WarningSignalWords = warningSignalWords.Select(x => new WarningSignalWordFormViewModel{Id = x.Id, SignalWordText = x.SignalWordText}).ToList()
        };
        
        return viewModel;
    }
}