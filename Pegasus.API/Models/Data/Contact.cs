namespace Pegasus.API.Models.Data;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ContactPhoneNumber> PhoneNumbers { get; set; } = new List<ContactPhoneNumber>();
}
