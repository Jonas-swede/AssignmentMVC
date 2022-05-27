﻿// <auto-generated />
using Assignment_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Assignment_MVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Assignment_MVC.Models.City", b =>
                {
                    b.Property<int>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CityID");

                    b.HasIndex("CountryName");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            CityID = 1,
                            CityName = "Stockholm",
                            CountryName = "Sverige"
                        },
                        new
                        {
                            CityID = 2,
                            CityName = "Göteborg",
                            CountryName = "Sverige"
                        },
                        new
                        {
                            CityID = 3,
                            CityName = "Oslo",
                            CountryName = "Norge"
                        });
                });

            modelBuilder.Entity("Assignment_MVC.Models.Country", b =>
                {
                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CountryName");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryName = "Sverige"
                        },
                        new
                        {
                            CountryName = "Norge"
                        },
                        new
                        {
                            CountryName = "Finland"
                        });
                });

            modelBuilder.Entity("Assignment_MVC.Models.Language", b =>
                {
                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LanguageName");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            LanguageName = "English"
                        },
                        new
                        {
                            LanguageName = "Svenska"
                        },
                        new
                        {
                            LanguageName = "Norsk"
                        });
                });

            modelBuilder.Entity("Assignment_MVC.Models.Person", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("CityID");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            id = 1,
                            CityID = 1,
                            Name = "Kalle",
                            PhoneNumber = "01234562"
                        },
                        new
                        {
                            id = 2,
                            CityID = 2,
                            Name = "Sten",
                            PhoneNumber = "01698941"
                        },
                        new
                        {
                            id = 3,
                            CityID = 2,
                            Name = "Börje",
                            PhoneNumber = "016161814"
                        });
                });

            modelBuilder.Entity("Assignment_MVC.Models.PersonLanguage", b =>
                {
                    b.Property<int>("Personid")
                        .HasColumnType("int");

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Personid", "LanguageName");

                    b.HasIndex("LanguageName");

                    b.ToTable("PersonLanguage");

                    b.HasData(
                        new
                        {
                            Personid = 1,
                            LanguageName = "Svenska"
                        },
                        new
                        {
                            Personid = 2,
                            LanguageName = "Svenska"
                        },
                        new
                        {
                            Personid = 2,
                            LanguageName = "English"
                        },
                        new
                        {
                            Personid = 3,
                            LanguageName = "Norsk"
                        });
                });

            modelBuilder.Entity("Assignment_MVC.Models.City", b =>
                {
                    b.HasOne("Assignment_MVC.Models.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryName");
                });

            modelBuilder.Entity("Assignment_MVC.Models.Person", b =>
                {
                    b.HasOne("Assignment_MVC.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment_MVC.Models.PersonLanguage", b =>
                {
                    b.HasOne("Assignment_MVC.Models.Language", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LanguageName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment_MVC.Models.Person", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("Personid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
