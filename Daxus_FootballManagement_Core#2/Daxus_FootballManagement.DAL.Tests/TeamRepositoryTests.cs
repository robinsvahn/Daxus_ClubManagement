using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model;
using Daxus_FootballManagement.DAL.Repositories.Implementations;
using Daxus_FootballManagement.DAL.Tests.Interfaces;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Daxus_FootballManagement.DAL.Tests
{
    public class TeamRepositoryTests : IGenericRepositoryTest
    {
        private DaxusContext GetContextWithData()
        {
            var options = new DbContextOptionsBuilder<DaxusContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging(true)
                .Options;
            var context = new DaxusContext(options);

            #region Add Range
            context.Teams.AddRange(
                new List<Team>(){
                    new Team(){Id = 1, Name = "Manchester United", Country = "England", Tier = 1},
                    new Team(){Id = 2, Name = "IFK Göteborg", Country = "Sweden", Tier = 2},
                    new Team(){Id = 3, Name = "FC Oberwinterthur", Country = "Switzerland", Tier = 5},
                    new Team(){Id = 40, Name = "FC Phoenix", Country = "Switzerland", Tier = 4},
                    new Team(){Id = 47, Name = "Totenham", Country = "England", Tier = 1},
                });
            #endregion
            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task GetAll_WithNothing_ShouldReturnCorrectNumberOfEntities()
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var teamRepository = new TeamRepository(context);
                int expectedAmountOfTeams = 5;

                //Act
                var result = await teamRepository.GetAllAsync();

                //Assert
                Assert.NotNull(result);
                Assert.NotEmpty(result);
                Assert.Equal(result.Count(), expectedAmountOfTeams);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public async Task GetByIdAysnc_WithValidIds_ShouldReturnValidEntities(int id)
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var teamRepository = new TeamRepository(context);

                //Act
                var result = await teamRepository.GetByIdAsync(id);

                //Assert
                Assert.NotNull(result);
                Assert.IsType<Team>(result);
            }
        }

        [Fact]
        public async Task AddAsync_WithValidData_ShouldAddEntityToLastPositionInList()
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var teamRepository = new TeamRepository(context);
                var listOfGuestsBefore = context.Teams.ToList();
                var newTeam = new Team
                {
                    Id = 2000,
                    Name = "Manchester City",
                    Country = "England",
                    Tier = 1,
                };

                //Act
                await teamRepository.AddAsync(newTeam);

                //Assert
                var listOfTeamsAfter = context.Teams.ToList();

                Assert.NotNull(listOfTeamsAfter);
                Assert.NotEmpty(listOfTeamsAfter);
                Assert.IsType<List<Team>>(listOfTeamsAfter);

                Assert.NotEqual(listOfGuestsBefore, listOfTeamsAfter);
                Assert.True(listOfGuestsBefore.Count < listOfTeamsAfter.Count);
                Assert.Equal(newTeam, listOfTeamsAfter.Last());
            }
        }

        [Theory]
        [InlineData(1, "Manchester United F.C.")]
        [InlineData(2, "Blå Vitt")]
        [InlineData(3, "FC Oberi")]
        public async Task UpdateAsync_WithValidPropertyData_ShouldUpdateEntities(int idToTest, string newTeamName)
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var teamRepository = new TeamRepository(context);
                var teamBefore = context.Teams.First(x => x.Id == idToTest);
                var nameBefore = teamBefore.Name;

                teamBefore.Name = newTeamName;

                //Act
                await teamRepository.UpdateAsync(teamBefore);

                //Assert
                var teamAfter = context.Teams.First(x => x.Id == idToTest);

                Assert.NotNull(teamAfter);
                Assert.IsType<Team>(teamAfter);
                Assert.NotEqual(nameBefore, teamAfter.Name);
                Assert.Equal(teamAfter.Name, newTeamName);
            }
        }

        [Fact]
        public async Task UpdateAsync_WithValidEntityCopyButChangedProperty_ShouldUpdateEntitytWithNewPropertyValue()
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var teamRepository = new TeamRepository(context);

                var updatedTeam = new Team
                {
                    Id = 2,
                    Name = "Örgryte",
                    Country = "Sweden",
                    Tier = 3,
                };

                var teamNameBefore = context.Teams.First(x => x.Id == updatedTeam.Id).Name;

                //Act
                await teamRepository.UpdateAsync(updatedTeam);

                //Assert
                var teamAfter = context.Teams.First(x => x.Id == updatedTeam.Id);

                Assert.NotNull(teamAfter);
                Assert.IsType<Team>(teamAfter);
                Assert.NotEqual(teamNameBefore, teamAfter.Name);
                Assert.Equal(teamAfter.Name, updatedTeam.Name);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(47)]
        public async Task DeleteAsync_WithValidGuest_ShouldRemoveGuestFromList(int idToDelete)
        {
            using (var context = GetContextWithData())
            {
                //Arrange
                var teamRepository = new TeamRepository(context);
                var listOfTeamsBefore = context.Teams.ToList();
                var teamToDelete = context.Teams.First(x => x.Id == idToDelete);

                //Act
                await teamRepository.DeleteAsync(teamToDelete);

                //Assert
                var listOfTeamsAfter = context.Teams.ToList();

                Assert.NotNull(listOfTeamsAfter);
                Assert.NotEmpty(listOfTeamsAfter);
                Assert.NotEqual(listOfTeamsBefore, listOfTeamsAfter);
                Assert.True(listOfTeamsBefore.Count > listOfTeamsAfter.Count);
                Assert.Contains(teamToDelete, listOfTeamsBefore);
                Assert.DoesNotContain(teamToDelete, listOfTeamsAfter);
            }
        }
    }
}
