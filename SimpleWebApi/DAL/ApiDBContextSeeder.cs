using Microsoft.EntityFrameworkCore;
using SimpleWebApi.Models;

namespace SimpleWebApi.DAL
{
    public class ApiDBContextSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incident>()
                .HasData(new Incident() { Name = "Test1", Description = "Desc1"},
                new Incident() { Name = "Test2", Description = "Desc2" },
                new Incident() { Name = "Test3", Description = "Desc3" },
                new Incident() { Name = "Test4", Description = "Desc4" });

            modelBuilder.Entity<Account>()
                .HasData(new Account() { Id = 1, Name = "Acc1", IncidentId = "Test1" },
                new Account() { Id = 2, Name = "Acc2", IncidentId = "Test2" },
                new Account() { Id = 3, Name = "Acc3", IncidentId = "Test3" },
                new Account() { Id = 4, Name = "Acc4", IncidentId = "Test4" });

            modelBuilder.Entity<Contact>()
                .HasData(new Contact() { Id = 1, FirstName = "Dima", LastName = "Kozak", Email = "test@gmail.com", AccountId = 1 },
                new Contact() { Id = 2, FirstName = "Orest", LastName = "Krasnevuch", Email = "test@gmail.com", AccountId = 2 },
                new Contact() { Id = 3, FirstName = "Dima", LastName = "Kvuk", Email = "test@gmail.com", AccountId = 3 },
                new Contact() { Id = 4, FirstName = "Oleg", LastName = "Svyshch", Email = "test@gmail.com", AccountId = 4 });


        }
    }
    
}
