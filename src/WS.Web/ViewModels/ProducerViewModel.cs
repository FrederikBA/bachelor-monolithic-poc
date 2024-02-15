namespace WS.Web.ViewModels;

public class ProducerViewModel
{
    public int Id { get; set; }
    public string? CompanyName { get; set; }
    public string? PhoneNumber { get; set; }
    public ProducerAddressViewModel? Address { get; set; }
}