﻿// <auto-generated />
using Daxus_FootballManagement.DAL.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Daxus_FootballManagement.DAL.Migrations
{
    [DbContext(typeof(DaxusContext))]
    partial class DaxusContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Daxus_FootballManagement.DAL.Model.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PlayerId");

                    b.Property<double>("Salary");

                    b.Property<int?>("TeamId");

                    b.Property<DateTime>("ValidFrom");

                    b.Property<DateTime>("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("Daxus_FootballManagement.DAL.Model.Guest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("FakeChange");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Guests");
                });

            modelBuilder.Entity("Daxus_FootballManagement.DAL.Model.GuestSlot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("GuestSlot");
                });

            modelBuilder.Entity("Daxus_FootballManagement.DAL.Model.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Birthdate");

                    b.Property<string>("Firstname")
                        .IsRequired();

                    b.Property<string>("Lastname")
                        .IsRequired();

                    b.Property<DateTime>("Registered");

                    b.HasKey("Id");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("Daxus_FootballManagement.DAL.Model.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("Daxus_FootballManagement.DAL.Model.Contract", b =>
                {
                    b.HasOne("Daxus_FootballManagement.DAL.Model.Player", "Player")
                        .WithMany("Contracts")
                        .HasForeignKey("PlayerId");

                    b.HasOne("Daxus_FootballManagement.DAL.Model.Team", "Team")
                        .WithMany("Contracts")
                        .HasForeignKey("TeamId");
                });

            modelBuilder.Entity("Daxus_FootballManagement.DAL.Model.GuestSlot", b =>
                {
                    b.HasOne("Daxus_FootballManagement.DAL.Model.Player")
                        .WithMany("GuestSlots")
                        .HasForeignKey("PlayerId");
                });
#pragma warning restore 612, 618
        }
    }
}
