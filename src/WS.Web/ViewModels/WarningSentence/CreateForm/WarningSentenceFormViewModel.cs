namespace WS.Web.ViewModels.WarningSentence.CreateForm;

public class WarningSentenceFormViewModel
{
    public List<WarningCategoryFormViewModel> WarningCategories { get; set; }
    public List<WarningPictogramFormViewModel> WarningPictograms { get; set; }
    public List<WarningSignalWordFormViewModel> WarningSignalWords { get; set; }
}