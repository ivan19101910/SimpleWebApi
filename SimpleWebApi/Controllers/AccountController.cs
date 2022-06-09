using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.DAL;
using SimpleWebApi.DTOs;
using SimpleWebApi.Models;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        ApiDBContext db;
        private IMapper _mapper;
        public AccountController(ApiDBContext context, IMapper mapper)
        {
            db = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Account>> GetAll()
        {
            return db.Accounts.ToList();
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Account>> Create(AccountDTO account)
        {
            var contact = db.Contacts.Where(x => x.Email == account.ContactEmail).FirstOrDefault();
            if (contact == null)
            {
                return NotFound();
            }
            if (account == null)
            {
                return BadRequest();
            }
            var mappedAccount = _mapper.Map<AccountDTO, Account>(account);
            mappedAccount.IncidentId = null;
            var existedAccount = db.Accounts.Where(x => x.Name == account.Name).FirstOrDefault();
            if (existedAccount != null)
            {
                return StatusCode(409, $"Account '{account.Name}' already exists.");
            }
            db.Accounts.Add(mappedAccount);
            await db.SaveChangesAsync();
            contact.AccountId = mappedAccount.Id;
            db.Contacts.Update(contact);
            await db.SaveChangesAsync();
            return Ok(account);
        }

    }
}
