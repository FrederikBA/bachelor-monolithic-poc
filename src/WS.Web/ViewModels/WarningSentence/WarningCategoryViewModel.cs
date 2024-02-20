namespace WS.Web.ViewModels.WarningSentence;

public class WarningCategoryViewModel
{
    public string? Text { get; set; }
    public int WarningTypeId { get; set; }
    public int SortOrder { get; set; }
    public WarningTypeViewModel? WarningType { get; set; }
}