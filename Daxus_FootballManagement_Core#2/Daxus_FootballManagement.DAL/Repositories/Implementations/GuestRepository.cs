using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model;
using Daxus_FootballManagement.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Daxus_FootballManagement.DAL.Repositories.Implementations
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DaxusContext _daxusContext;
        private readonly IMapper _iMapper;

        public GuestRepository(DaxusContext daxusContext)
        {
            _daxusContext = daxusContext;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Guest, Guest>();
            });

            _iMapper = config.CreateMapper();
        }

        public async Task<IEnumerable<Guest>> GetAllAsync()
        {
            return await _daxusContext.Guests.ToListAsync();
        }

        public async Task<Guest> GetByIdAsync(int id)
        {
            return await _daxusContext.Guests.FindAsync(id);
        }

        public async Task AddAsync(Guest guest)
        {
            if (guest == null) return;

            await _daxusContext.Guests.AddAsync(guest);
            _daxusContext.Entry(guest).State = EntityState.Added;

            await SaveAsync();
        }

        public async Task UpdateAsync(Guest guest)
        {
            if (guest == null) return;
            var guestInList = await _daxusContext.Guests.FindAsync(guest.Id);
            if (guestInList == null) return;
            
            guestInList = _iMapper.Map(guest, guestInList);

            _daxusContext.Entry(guestInList).State = EntityState.Modified;

            await SaveAsync();
        }

        public async Task DeleteAsync(Guest guest)
        {
            guest = await _daxusContext.Guests.FindAsync(guest.Id);
            if (guest == null) return;

            _daxusContext.Guests.Remove(guest);

            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _daxusContext.SaveChangesAsync();
        }
    }
}