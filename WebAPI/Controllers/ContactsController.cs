
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Context;
using WebAPI.DTOs.ContactDTO;
using WebAPI.Entities;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly APIContext _context;

        public ContactsController(APIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values =  _context.Contacts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            Contact contact = new Contact();

            contact.Email = createContactDTO.Email;
            contact.Address = createContactDTO.Address;
            contact.PhoneNumber = createContactDTO.PhoneNumber;
            contact.MapLocation = createContactDTO.MapLocation;
            contact.OpenHours = createContactDTO.OpenHours;

            _context.Contacts.Add(contact);
            _context.SaveChanges();

            return Ok("Contact Created Succesfully!");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();

            return Ok("Contact Deleted Succesfully");
        }

        [HttpGet("GetContact/ById")]
        public IActionResult GetContactById(int id)
        {
            return Ok(_context.Contacts.Find(id));
        }

        [HttpPut]
        public IActionResult ContactUpdate(UpdateContactDTO updateContactDTO)
        {
            Contact contact = new Contact();

            contact.Email = updateContactDTO.Email;
            contact.Address = updateContactDTO.Address;
            contact.PhoneNumber = updateContactDTO.PhoneNumber;
            contact.MapLocation = updateContactDTO.MapLocation;
            contact.ContactId = updateContactDTO.ContactId;
            contact.OpenHours = updateContactDTO.OpenHours;

            _context.Contacts.Update(contact);
            _context.SaveChanges();

            return Ok("Contact Updated Succesfully!");
        }
    }
}
