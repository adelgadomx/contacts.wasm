using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using repositories;
using shared;

namespace server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;

    public ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Contact contact)
    {
        if (contact is null)
            return BadRequest();
        if (string.IsNullOrEmpty(contact.FirstName))
            ModelState.AddModelError("FirstName", "First Name can't be empty");
        if (string.IsNullOrEmpty(contact.LastName))
            ModelState.AddModelError("LastName", "Last Name can't be empty");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _contactRepository.InsertContact(contact);

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Contact contact)
    {
        if (contact is null)
            return BadRequest();
        if (string.IsNullOrEmpty(contact.FirstName))
            ModelState.AddModelError("FirstName", "First Name can't be empty");
        if (string.IsNullOrEmpty(contact.LastName))
            ModelState.AddModelError("LastName", "Last Name can't be empty");

        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _contactRepository.UpdateContact(id, contact);

        return NoContent();
    }

    [HttpGet]
    public async Task<IEnumerable<Contact>> GetAll()
    {
        return await _contactRepository.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Contact> GetDetail(int id)
    {
        return await _contactRepository.GetDetails(id);
    }

    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await _contactRepository.DeleteContact(id);
    }


}