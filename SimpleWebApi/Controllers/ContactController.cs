using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.DAL;
using SimpleWebApi.DTOs;
using SimpleWebApi.Models;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        ApiDBContext db;
        private IMapper _mapper;
        public ContactController(ApiDBContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Contact>> GetAll()
        {
            return db.Contacts.ToList();
        }
        
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Contact>> Create(ContactDTO contact)
        {
            if (contact == null)
            {
                return BadRequest();
            }
            var mappedContact = _mapper.Map<ContactDTO, Contact>(contact);
            mappedContact.AccountId = null;
            db.Contacts.Add(mappedContact);
            await db.SaveChangesAsync();
            return Ok(contact);
        }
    }
}
