using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Models;

namespace SimpleWebApi.DAL
{
    public class ApiDBContext : DbContext
    {
        public ApiDBContext(DbContextOptions<ApiDBContext> options)
           : base(options)
        {
            
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Incident> Incidents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasOne(a => a.Incident)
                .WithMany(au => au.Accounts)
                .HasForeignKey(a => a.IncidentId)
                .IsRequired(false);

            ApiDBContextSeeder.Seed(modelBuilder);
        }
    }
}
