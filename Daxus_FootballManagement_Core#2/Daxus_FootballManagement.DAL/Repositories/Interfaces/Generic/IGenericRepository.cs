using System.Collections.Generic;
using System.Threading.Tasks;
using Daxus_FootballManagement.DAL.Model.Interfaces;

namespace Daxus_FootballManagement.DAL.Repositories.Interfaces.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);

        Task SaveAsync();
    }
}
