using Assignment_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
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
                .HasForeignKey(k => k.CountryId);

            modelBuilder.Entity<Person>()
                .HasOne(c => c.City)
                .WithMany(p => p.People)
                .HasForeignKey(k => k.CityID);

            modelBuilder.Entity<PersonLanguage>().HasKey(k => new { k.Personid, k.LanguageId });
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(pl => pl.Person)
                .WithMany(p => p.PersonLanguages)
                .HasForeignKey(k => k.Personid);
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(l => l.Language)
                .WithMany(l => l.PersonLanguages)
                .HasForeignKey(k => k.LanguageId);

            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 1, CountryName = "Sverige" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 2, CountryName = "Norge" });
            modelBuilder.Entity<Country>().HasData(new Country { CountryId = 3, CountryName = "Finland" });


            modelBuilder.Entity<City>().HasData(new City { CityName = "Stockholm", CityID = 1, CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Göteborg", CityID = 2, CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { CityName = "Oslo", CityID = 3, CountryId = 2 });


            modelBuilder.Entity<Person>().HasData(new Person { id = 1, Name = "Kalle",CityID=1, PhoneNumber = "01234562" });
            modelBuilder.Entity<Person>().HasData(new Person { id = 2, Name = "Sten", CityID=2, PhoneNumber = "01698941" });
            modelBuilder.Entity<Person>().HasData(new Person { id = 3, Name = "Börje", CityID = 2, PhoneNumber = "016161814" });


            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 1,LanguageName = "English" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 2, LanguageName = "Svenska" });
            modelBuilder.Entity<Language>().HasData(new Language { LanguageId = 3, LanguageName = "Norsk" });

            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { Personid = 1, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { Personid = 2, LanguageId = 2 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { Personid = 2, LanguageId = 1 });
            modelBuilder.Entity<PersonLanguage>().HasData(new PersonLanguage { Personid = 3, LanguageId = 3 });

            string adminRoleId = Guid.NewGuid().ToString();
            string userRoleId = Guid.NewGuid().ToString();
            string userId = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole() { Id = userRoleId, Name = "User", NormalizedName = "USER" }
                );
            ApplicationUser user = new ApplicationUser()
            {
                Id = userId,
                UserName = "admin@gmail.com",
                NormalizedUserName="ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail="ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };
            

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            user.PasswordHash=passwordHasher.HashPassword(user, "Admin123!");

            modelBuilder.Entity<ApplicationUser>().HasData(user);

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = adminRoleId, UserId = userId }
                );




            base.OnModelCreating(modelBuilder);
        

        
        }

        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        public DbSet<Language> Language { get; set; }

        public DbSet<PersonLanguage> PersonLanguage { get; set; }
       

        
    }
}
