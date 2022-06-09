using Microsoft.EntityFrameworkCore;

namespace SimpleWebApi.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? IncidentId { get; set; }
        public virtual Incident Incident { get; set; }
    }
}
