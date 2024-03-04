using WS.Web.ViewModels.WarningSentence;
using WS.Web.ViewModels.WarningSentence.CreateForm;

namespace WS.Web.Interfaces;

public interface IWarningSentenceModalService
{
    Task<WarningSentenceBaseViewModel> GetWarningSentenceModalAsync(int id);
    Task<List<WarningSentenceBaseViewModel>> GetWarningSentencesModalAsync(List<int> ids);
    Task<WarningSentenceFormViewModel> GetCreateFormModalAsync();
}