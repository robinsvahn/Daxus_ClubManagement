using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model;
using Daxus_FootballManagement.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Xunit;

namespace Daxus_FootballManagement.DAL.Tests
{
    public class GuestRepositoryTests
    {
        private DaxusContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<DaxusContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging(true)
                .Options;
            var context = new DaxusContext(options);

            #region Add Range
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
            #endregion
            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task GetAll_WithNothing_ShouldReturnNineGuests()
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var guestRepository = new GuestRepository(context);
                int expectedAmountOfGuests = 9;

                //Act
                var result = await guestRepository.GetAllAsync();

                //Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Equal(result.Count(), expectedAmountOfGuests);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetByIdAysnc_WithValidIds_ShouldReturnValidGuests(int id)
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var guestRepository = new GuestRepository(context);

                //Act
                var result = await guestRepository.GetByIdAsync(id);

                //Assert
                Assert.NotNull(result);
                Assert.IsType<Guest>(result);
            }
        }

        /// <summary>
        /// Tests if users are added correctly
        /// </summary>
        [Fact]
        public async Task AddAsync_WithValidUser_ShouldAddUserToLastPositionInList()
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var guestRepository = new GuestRepository(context);
                var listOfGuestsBefore = context.Guests.ToList();
                var newGuest = new Guest
                {
                    Id = 2000,
                    Birthdate = new DateTime(1995, 2, 17),
                    CreatedOn = DateTime.UtcNow,
                    Firstname = "Jacob",
                    Lastname = "Wilder"
                };

                //Act
                await guestRepository.AddAsync(newGuest);

                //Assert
                var listOfGuestsAfter = context.Guests.ToList();

                Assert.NotNull(listOfGuestsAfter);
                Assert.NotEmpty(listOfGuestsAfter);
                Assert.IsType<List<Guest>>(listOfGuestsAfter);

                Assert.NotEqual(listOfGuestsBefore, listOfGuestsAfter);
                Assert.True(listOfGuestsBefore.Count < listOfGuestsAfter.Count);
                Assert.Equal(newGuest, listOfGuestsAfter.Last());
            }
        }

        [Theory]
        [InlineData(1, "Ruben")]
        [InlineData(2, "Bruno")]
        [InlineData(3, "Jim")]
        public async Task UpdateAsync_WithValidFirstnames(int idToTest, string firstname)
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var guestRepository = new GuestRepository(context);
                var guestBefore1 = context.Guests.First(x => x.Id == idToTest);
                var nameBefore = guestBefore1.Firstname;

                guestBefore1.Firstname = firstname;

                //Act
                await guestRepository.UpdateAsync(guestBefore1);

                //Assert
                var guestAfter1 = context.Guests.First(x => x.Id == idToTest);

                Assert.NotNull(guestAfter1);
                Assert.IsType<Guest>(guestAfter1);
                Assert.NotEqual(nameBefore, guestAfter1.Firstname);
                Assert.Equal(guestAfter1.Firstname, firstname);
            }
        }

        [Fact]
        public async Task UpdateAsync_WithValidCopyWithNewName_ShouldUpdateGuestWithNewName()
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var guestRepository = new GuestRepository(context);

                var updatedGuest = new Guest
                {
                    Id = 66,
                    Birthdate = new DateTime(1989, 03, 06),
                    CreatedOn = DateTime.UtcNow,
                    Firstname = "Steffan",
                    Lastname = "Haas"
                };

                var firstnameBefore = context.Guests.First(x => x.Id == updatedGuest.Id).Firstname;

                //Act
                await guestRepository.UpdateAsync(updatedGuest);

                //Assert
                var guestAfter = context.Guests.First(x => x.Id == updatedGuest.Id);

                Assert.NotNull(guestAfter);
                Assert.IsType<Guest>(guestAfter);
                Assert.NotEqual(firstnameBefore, guestAfter.Firstname);
                Assert.Equal(guestAfter.Firstname, updatedGuest.Firstname);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(71)]
        public async Task DeleteAsync_WithValidGuest_ShouldRemoveGuestFromList(int idToDelete)
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var guestRepository = new GuestRepository(context);
                var listOfGuestsBefore = context.Guests.ToList();
                var guestToDelete = context.Guests.First(x => x.Id == idToDelete);

                //Act
                await guestRepository.DeleteAsync(guestToDelete);

                //Assert
                var listOfGuestsAfter = context.Guests.ToList();
                Assert.NotNull(listOfGuestsAfter);
                Assert.NotEmpty(listOfGuestsAfter);
                Assert.NotEqual(listOfGuestsBefore, listOfGuestsAfter);
                Assert.True(listOfGuestsBefore.Count > listOfGuestsAfter.Count);
                Assert.Contains(guestToDelete, listOfGuestsBefore);
                Assert.DoesNotContain(guestToDelete, listOfGuestsAfter);
            }
        }
    }
}
