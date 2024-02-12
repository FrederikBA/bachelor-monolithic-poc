namespace WS.Core.Entities.WSAggregate;

public class WarningType : BaseEntity
{
    public string? Type { get; set; }
    public int Priority { get; set; }
}