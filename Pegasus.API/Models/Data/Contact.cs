namespace Pegasus.API.Models.Data;

public class Contact
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<ContactPhoneNumber> PhoneNumbers { get; set; } = new List<ContactPhoneNumber>();
}
