using Assignment_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Data
{
    public class ApplicationDbContext : DbContext,IPersonData
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new Person { id = 1, Name = "Kalle", City = "Stad 1", PhoneNumber = "01234562" });
            modelBuilder.Entity<Person>().HasData(new Person { id = 2, Name = "Sten", City = "Stad 2", PhoneNumber = "01698941" });
            modelBuilder.Entity<Person>().HasData(new Person { id = 3, Name = "Börje", City = "Stad 3", PhoneNumber = "016161814" });
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> People { get; set; }

        public string SearchString { get ; set ; }
        public List<Person> persons { get; set; }

        public bool AddPerson(Person p)
        {
            People.Add(p);
            return this.SaveChanges()>0?true:false;


        }

        public bool EditPerson(int id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {

            return this.Set<Person>().ToList();
        }

        public Person GetById(int id)
        {
            return People.Find(id);
        }

        public bool RemovePerson(int id)
        {
            Person personToRemove = GetById(id);
            People.Remove(personToRemove);
            return this.SaveChanges() > 0 ? true : false;
        }
    }
}
