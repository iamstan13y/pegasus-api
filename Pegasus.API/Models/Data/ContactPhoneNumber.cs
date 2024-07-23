namespace Pegasus.API.Models.Data;

public class ContactPhoneNumber
{
    public long Id { get; set; }
    public string PhoneNumber { get; set; }
    public long ContactId { get; set; }
    public Contact Contact { get; set; }
}