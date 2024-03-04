using WS.Web.ViewModels.WarningSentence;

namespace WS.Web.Interfaces;

public interface IWarningSentenceModalService
{
    Task<WarningSentenceBaseViewModel> GetWarningSentenceModalAsync(int id);
}