﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleWebApi.DAL;

#nullable disable

namespace SimpleWebApi.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    [Migration("20220609070452_nullable_foreignkeys")]
    partial class nullable_foreignkeys
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SimpleWebApi.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IncidentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("IncidentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IncidentId = "Test1",
                            Name = "Славута"
                        },
                        new
                        {
                            Id = 2,
                            IncidentId = "Test2",
                            Name = "Львів"
                        },
                        new
                        {
                            Id = 3,
                            IncidentId = "Test3",
                            Name = "Київ"
                        },
                        new
                        {
                            Id = 4,
                            IncidentId = "Test4",
                            Name = "Івано-Франківськ"
                        });
                });

            modelBuilder.Entity("SimpleWebApi.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1,
                            Email = "test@gmail.com",
                            FirstName = "Dima",
                            LastName = "Kozak"
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 2,
                            Email = "test@gmail.com",
                            FirstName = "Orest",
                            LastName = "Krasnevuch"
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 3,
                            Email = "test@gmail.com",
                            FirstName = "Dima",
                            LastName = "Kvuk"
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 4,
                            Email = "test@gmail.com",
                            FirstName = "Oleg",
                            LastName = "Svyshch"
                        });
                });

            modelBuilder.Entity("SimpleWebApi.Models.Incident", b =>
                {
                    b.Property<string>("Name")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            Name = "Test1",
                            Description = "Desc1"
                        },
                        new
                        {
                            Name = "Test2",
                            Description = "Desc2"
                        },
                        new
                        {
                            Name = "Test3",
                            Description = "Desc3"
                        },
                        new
                        {
                            Name = "Test4",
                            Description = "Desc4"
                        });
                });

            modelBuilder.Entity("SimpleWebApi.Models.Account", b =>
                {
                    b.HasOne("SimpleWebApi.Models.Incident", "Incident")
                        .WithMany()
                        .HasForeignKey("IncidentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Incident");
                });

            modelBuilder.Entity("SimpleWebApi.Models.Contact", b =>
                {
                    b.HasOne("SimpleWebApi.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}
