using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model;
using Daxus_FootballManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daxus_FootballManagement.DAL.Repositories.Implementations
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DaxusContext _daxusDb;

        public GuestRepository()
        {
            _daxusDb = new DaxusContext();
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            return await _daxusDb.Guests.ToListAsync();
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            Guest guest = await _daxusDb.Guests.FindAsync(id);

            return guest;
        }

        public async Task AddAsync(Guest guest)
        {
            await _daxusDb.Guests.AddAsync(guest);
        }

        public async Task UpdateAsync(Guest guest)
        {
            _daxusDb.Guests.Attach(guest);
            _daxusDb.Entry(guest).State = EntityState.Modified;
        }

        public async Task DeleteAsync(Guest guest)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}