using System;
using System.Collections.Generic;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Daxus_FootballManagement.DAL.Tests
{
    public class GuestRepositoryTest
    {
        private DaxusContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<DaxusContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DaxusContext(options);

            context.Guests.AddRange(
            new List<Guest>(){
                new Guest(){Id = 1, Birthdate = new DateTime(1995, 04, 22), CreatedOn = DateTime.Today, Firstname = "Marco", Lastname = "Andersen"},
                new Guest(){Id = 2, Birthdate = new DateTime(1990, 01, 19), CreatedOn = DateTime.UtcNow, Firstname = "Adam", Lastname = "Karlsson"},
                new Guest(){Id = 3, Birthdate = new DateTime(1998, 10, 27), CreatedOn = DateTime.Today, Firstname = "Eric", Lastname = "Strasser"},
                new Guest(){Id = 40, Birthdate = new DateTime(1997, 06, 10), CreatedOn = DateTime.Today, Firstname = "Phillip", Lastname = "Schumacher"},
                new Guest(){Id = 59, Birthdate = new DateTime(1985, 12, 07), CreatedOn = DateTime.UtcNow, Firstname = "Carl", Lastname = "Hansen"},
                new Guest(){Id = 66, Birthdate = new DateTime(1989, 03, 06), CreatedOn = DateTime.UtcNow, Firstname = "Magnus", Lastname = "Haas"},
                new Guest(){Id = 71, Birthdate = new DateTime(1975, 08, 28), CreatedOn = DateTime.Today, Firstname = "Nils", Lastname = "Berg"},
                new Guest(){Id = 108, Birthdate = new DateTime(2000, 08, 30), CreatedOn = DateTime.UtcNow, Firstname = "Patrick", Lastname = "Himmel"},
                new Guest(){Id = 978, Birthdate = new DateTime(1999, 07, 02), CreatedOn = DateTime.Today, Firstname = "Emil", Lastname = "Bauder"},
            });

            context.SaveChanges();

            return context;
        }



        [Fact]
        public void Test1()
        {

        }
    }
}
