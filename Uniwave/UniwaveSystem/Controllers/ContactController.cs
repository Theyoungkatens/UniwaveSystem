using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniwaveSystem.Data;
using UniwaveSystem.DTOs;
using UniwaveSystem.Models;

namespace UniwaveSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _context.Contacts.OrderByDescending(c => c.CreatedDate).ToListAsync();
            return Ok(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitContact(ContactDto dto)
        {
            var contact = new Contact
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Message = dto.Message,
                CreatedDate = DateTime.UtcNow
            };

            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Contact submitted successfully." });
        }

    }
}
