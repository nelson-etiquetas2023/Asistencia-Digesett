using Digesett.Server.Data;
using Digesett.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Digesett.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController(AppDbContext context) : ControllerBase
    {
        public AppDbContext Context { get; set; } = context;

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await Context.Contacts.ToListAsync();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<ActionResult> AddContact(Contact Contacto) 
        {
            var addItem = await Context.Contacts.AddAsync(Contacto);
            await Context.SaveChangesAsync();
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetContactById(int id) 
        {
            var contact = await Context.Contacts.FindAsync(id);
            if (contact is null) 
            {
                return NotFound("Contacto no encontrado...");
            }
            return Ok(contact);
        }
    }
}
