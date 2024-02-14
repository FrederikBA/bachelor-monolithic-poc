namespace WS.Core.Entities.ChemicalAggregate;

public class Producer : BaseEntity
{
    public string? CompanyName { get; set; }
    public string? ContactPerson { get; set; }
    public string? PhoneNumber { get; set; }
    public ProducerAddress? Address { get; set; }
}