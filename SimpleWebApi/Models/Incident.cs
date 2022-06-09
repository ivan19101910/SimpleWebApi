using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebApi.Models
{
    public class Incident 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
