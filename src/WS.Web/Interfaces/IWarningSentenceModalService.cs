using WS.Web.ViewModels.WarningSentence;

namespace WS.Web.Interfaces;

public interface IWarningSentenceModalService
{
    Task<WarningSentenceBaseViewModel> GetWarningSentenceModalAsync(int id);
    Task<List<WarningSentenceBaseViewModel>> GetWarningSentencesModalAsync(List<int> ids);
}