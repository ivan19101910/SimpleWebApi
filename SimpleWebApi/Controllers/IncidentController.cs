using Microsoft.AspNetCore.Mvc;
using SimpleWebApi.DAL;
using SimpleWebApi.DTOs;
using SimpleWebApi.Models;

namespace SimpleWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IncidentController : ControllerBase
    {

        ApiDBContext db;
        public IncidentController(ApiDBContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("getAll")]
        public ActionResult<List<Incident>> GetAll()
        {
            return db.Incidents.ToList();
        }
        [HttpPost]
        [Route("create")]
        public ActionResult<IncidentDTO> Create(IncidentDTO incident)
        {
            var account = db.Accounts.Where(x => x.Name == incident.AccountName).FirstOrDefault();
            if (account == null)
            {
                return NotFound();       
            }
            else
            {
                var contact = db.Contacts.Where(x => x.Email == incident.Email).FirstOrDefault();
                if(contact != null)
                {
                    if(contact.AccountId == null)
                    {
                        contact.AccountId = account.Id;
                    }
                    db.Update(contact);
                }
                else
                {
                    db.Contacts.Add(new Contact { FirstName = incident.FirstName, LastName = incident.LastName, Email = incident.Email, AccountId = account.Id });
                    var newIncident = new Incident { Description = incident.AccountName };
                    db.Incidents.Add(newIncident);
                    db.SaveChanges();
                    account.IncidentId = newIncident.Name;
                    db.Update(account);
                    var f = 5;
                }
            }

            return NotFound();
        }
    }
}
