
using shared;

namespace client.Services;

public interface IContactService 
{
    Task SaveContact(Contact contact);
    Task DeleteContact(int id);
    Task<IEnumerable<Contact>> Getall();
    Task<Contact> GetDetails(int id);
}