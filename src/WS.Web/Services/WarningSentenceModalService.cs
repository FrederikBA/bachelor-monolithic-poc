using WS.Core.Interfaces.DomainServices;
using WS.Web.Interfaces;
using WS.Web.ViewModels.WarningSentence;
using WS.Web.ViewModels.WarningSentence.CreateForm;

namespace WS.Web.Services;

public class WarningSentenceModalService : IWarningSentenceModalService
{
    private readonly IWarningSentenceService _warningSentenceService;

    public WarningSentenceModalService(IWarningSentenceService warningSentenceService)
    {
        _warningSentenceService = warningSentenceService;
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
        throw new NotImplementedException();
    }
}