using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model;
using Daxus_FootballManagement.DAL.Repositories.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;

namespace Daxus_FootballManagement.DAL.Repositories.Implementations
{
    public class TeamRepository : ITeamRepository
    {
        private readonly DaxusContext _daxusContext;

        public TeamRepository(DaxusContext daxusContext)
        {
            _daxusContext = daxusContext;
        }

        public async Task<IEnumerable<Team>> GetAllAsync()
        {
            return await _daxusContext.Teams.ToListAsync();
        }

        public async Task<Team> GetByIdAsync(int id)
        {
            return await _daxusContext.Teams.FindAsync(id);
        }

        public async Task AddAsync(Team team)
        {
            if (team == null) return;

            await _daxusContext.Teams.AddAsync(team);
            _daxusContext.Entry(team).State = EntityState.Added;

            await SaveAsync();
        }

        public async Task UpdateAsync(Team team)
        {
            if (team == null) return;
            var teamInList = await _daxusContext.Teams.FindAsync(team.Id);
            if (teamInList == null) return;

            teamInList.Contracts = team.Contracts;
            teamInList.Country = team.Country;
            teamInList.Name = team.Name;
            teamInList.Tier = team.Tier;

            _daxusContext.Entry(teamInList).State = EntityState.Modified;

            await SaveAsync();
        }

        public async Task DeleteAsync(Team team)
        {
            team = await _daxusContext.Teams.FindAsync(team.Id);
            if (team == null) return;

            _daxusContext.Teams.Remove(team);

            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _daxusContext.SaveChangesAsync();
        }
    }
}
