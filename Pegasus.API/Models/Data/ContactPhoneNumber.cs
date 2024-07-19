namespace Pegasus.API.Models.Data;

public class ContactPhoneNumber
{
    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public int ContactId { get; set; }
    public Contact Contact { get; set; }
}