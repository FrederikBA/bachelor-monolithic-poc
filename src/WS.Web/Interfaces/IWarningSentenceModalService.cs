using WS.Web.ViewModels.WarningSentence;
using WS.Web.ViewModels.WarningSentence.Form;

namespace WS.Web.Interfaces;

public interface IWarningSentenceModalService
{
    Task<WarningSentenceBaseViewModel> GetWarningSentenceModalAsync(int id);
    Task<List<WarningSentenceBaseViewModel>> GetWarningSentencesModalAsync(List<int> ids);
    Task<WarningSentenceFormViewModel> GetCreateFormModalAsync();
    Task<WarningSentenceEditFormViewModel> GetEditFormModalAsync(int id);
}