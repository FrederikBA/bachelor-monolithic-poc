namespace WS.Core.Entities.ChemicalAggregate;

public class ProducerAddress //ValueObject
{
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
}