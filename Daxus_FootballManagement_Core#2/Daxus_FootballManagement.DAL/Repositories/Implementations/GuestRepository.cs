﻿using System;
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
            if (guest == null) return;

            await _daxusDb.Guests.AddAsync(guest);
            await SaveAsync();
        }

        public async Task UpdateAsync(Guest guest)
        {
            if (guest == null) return;
            if (await _daxusDb.Guests.FindAsync(guest) == null) return;

            _daxusDb.Entry(guest).CurrentValues.SetValues(guest);
            _daxusDb.Entry(guest).State = EntityState.Modified;

            await SaveAsync();
        }

        public async Task DeleteAsync(Guest guest)
        {
            if (guest == null) return;
            if (await _daxusDb.Guests.FindAsync(guest) == null) return;

            _daxusDb.Set<Guest>().Remove(guest);
            _daxusDb.Entry(guest).State = EntityState.Deleted;

            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _daxusDb.SaveChangesAsync();
        }
    }
}