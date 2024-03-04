using WS.Core.Interfaces.DomainServices;
using WS.Web.Interfaces;
using WS.Web.ViewModels.WarningSentence;

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
}