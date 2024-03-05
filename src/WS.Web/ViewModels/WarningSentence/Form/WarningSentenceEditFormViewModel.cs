namespace WS.Web.ViewModels.WarningSentence.Form;

public class WarningSentenceEditFormViewModel
{
    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Text { get; set; }
    public List<WarningCategoryFormViewModel>? WarningCategories { get; set; }
    public List<WarningPictogramFormViewModel>? WarningPictograms { get; set; }
    public List<WarningSignalWordFormViewModel>? WarningSignalWords { get; set; }
}