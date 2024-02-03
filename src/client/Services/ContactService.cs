using System.Net.Http.Json;
using shared;

namespace client.Services;

public class ContactService : IContactService
{
    private readonly HttpClient _httpClient;

    public ContactService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task DeleteContact(int id)
    {
        await _httpClient.DeleteAsync($"api/contact/{id}");
    }

    public async Task<IEnumerable<Contact>> Getall()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Contact>>($"api/contact");
    }

    public async Task<Contact> GetDetails(int id)
    {
        return await _httpClient.GetFromJsonAsync<Contact>($"api/contact/{id}");
    }

    public async Task SaveContact(Contact contact)
    {
        if(contact.Id == 0)
            await _httpClient.PostAsJsonAsync<Contact>($"api/contact", contact);
        else
            await _httpClient.PutAsJsonAsync<Contact>($"api/contact/{contact.Id}", contact);
    }
}
