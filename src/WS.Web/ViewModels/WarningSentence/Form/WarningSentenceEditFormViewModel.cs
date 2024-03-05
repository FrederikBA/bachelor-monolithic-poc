namespace WS.Web.ViewModels.WarningSentence.Form;

public class WarningSentenceEditFormViewModel
{
    public WarningSentenceViewModel? WarningSentence { get; set; }
    public List<WarningCategoryFormViewModel>? WarningCategories { get; set; }
    public List<WarningPictogramFormViewModel>? WarningPictograms { get; set; }
    public List<WarningSignalWordFormViewModel>? WarningSignalWords { get; set; }
}