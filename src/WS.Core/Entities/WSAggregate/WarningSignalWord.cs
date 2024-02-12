namespace WS.Core.Entities.WSAggregate;

public class WarningSignalWord : BaseEntity
{
    public string? SignalWordText { get; set; }
    public int Priority { get; set; }
}