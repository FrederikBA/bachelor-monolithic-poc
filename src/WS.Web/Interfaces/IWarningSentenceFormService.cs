using WS.Web.ViewModels.WarningSentence.CreateForm;

namespace WS.Web.Interfaces;

public interface IWarningSentenceFormService
{
    Task<WarningSentenceFormViewModel> GetWarningSentenceCreateFormAsync(int id);
}