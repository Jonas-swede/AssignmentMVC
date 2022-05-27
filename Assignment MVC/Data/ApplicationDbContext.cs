using Assignment_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasKey(c => new { c.CityID });
            modelBuilder.Entity<City>()
                .HasOne(c => c.Country)
                .WithMany(ci => ci.Cities)
                .HasForeignKey(k => k.CountryName);

            modelBuilder.Entity<Person>()
                .HasOne(c => c.City)
                .WithMany(p => p.People)
                .HasForeignKey(k => k.CityID);

            modelBuilder.Entity<PersonLanguage>().HasKey(k => new { k.Personid, k.LanguageName });
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(k => k.Personid);
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(l => l.Language)
                .WithMany(l => l.PersonLanguages)
                .HasForeignKey(k => k.LanguageName);

            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Sverige" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Norge" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryName = "Finland" });


            modelBuilder.Entity<City>().HasData(new City { CityName = "Stockholm", CityID = 1, CountryName = "Sverige" });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Göteborg", CityID = 2, CountryName = "Sverige" });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Oslo", CityID = 3, CountryName = "Norge" });


            modelBuilder.Entity<Person>().HasData(new Person { id = 1, Name = "Kalle",CityID=1, PhoneNumber = "01234562" });
            modelBuilder.Entity<Person>().HasData(new Person { id = 2, Name = "Sten", CityID=2, PhoneNumber = "01698941" });
            modelBuilder.Entity<Person>().HasData(new Person { id = 3, Name = "Börje", CityID = 2, PhoneNumber = "016161814" });


            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Svenska" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageName = "Norsk" });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { Personid = 1, LanguageName = "Svenska" });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { Personid = 2, LanguageName = "Svenska" });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { Personid = 2, LanguageName = "English" });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { Personid = 3, LanguageName = "Norsk" });




            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<PersonLanguage> PersonLanguage { get; set; }
       
        
    }
}
