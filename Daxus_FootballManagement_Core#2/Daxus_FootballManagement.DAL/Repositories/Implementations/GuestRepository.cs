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

        public GuestRepository(DaxusContext daxusContext)
        {
            _daxusDb = daxusContext;
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            return await _daxusDb.Guests.ToListAsync();
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            return await _daxusDb.Guests.FindAsync(id);
        }

        public async Task AddAsync(Guest guest)
        {
            if (guest == null) return;

            await _daxusDb.Guests.AddAsync(guest);
            _daxusDb.Entry(guest).State = EntityState.Added;

            await SaveAsync();
        }

        public async Task UpdateAsync(Guest guest)
        {
            if (guest == null) return;
            var guestInList = await _daxusDb.Guests.FindAsync(guest.Id);
            if (guestInList == null) return;

            guestInList.Firstname = guest.Firstname;
            guestInList.Lastname = guest.Lastname;

            _daxusDb.Entry(guestInList).State = EntityState.Modified;

            await SaveAsync();
        }

        public async Task DeleteAsync(Guest guest)
        {
            guest = await _daxusDb.Guests.FindAsync(guest.Id);
            if (guest == null) return;

            _daxusDb.Guests.Remove(guest);

            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _daxusDb.SaveChangesAsync();
        }
    }
}