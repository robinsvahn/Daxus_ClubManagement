using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.DbContext;
using Daxus_FootballManagement.DAL.Model;
using Daxus_FootballManagement.DAL.Repositories.Interfaces;

namespace Daxus_FootballManagement.DAL.Repositories.Implementations
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DaxusContext _daxusDb;

        public GuestRepository()
        {
            _daxusDb = new DaxusContext();
        }

        public IEnumerable<Guest> GetAllAsync()
        {
            return _daxusDb.Guests.ToList();
        }

        public Task<Guest> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(Guest entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Guest entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guest entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}