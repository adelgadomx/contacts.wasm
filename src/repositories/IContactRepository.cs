using shared;

namespace repositories;

public interface IContactRepository
{
    Task<bool> InsertContact(Contact contact);
    Task<bool> UpdateContact(int id, Contact contact);
    Task DeleteContact(int Id);
    Task<IEnumerable<Contact>> GetAll();
    Task<Contact> GetDetails(int id);

}
