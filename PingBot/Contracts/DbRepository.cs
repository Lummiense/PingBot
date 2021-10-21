using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PingBot.Contracts.Entities;
using PingBot.Data;

namespace PingBot.Contracts
{
    public class DbRepository:IDbRepository
    {
        private readonly DataContext _dataContext;

        public DbRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IQueryable<T> Get<T>() where T : class, IEntity
        {
            
            return _dataContext.Set<T>().Where(x=> x.IsActive).AsQueryable();
        }

        public IQueryable<T> GetAll<T>() where T : class, IEntity
        {
            return _dataContext.Set<T>().AsQueryable();
        }

        public async Task<uint> Add<T>(T newEntity) where T : class, IEntity
        {
            var entity = await _dataContext.Set<T>().AddAsync(newEntity);
            return entity.Entity.Id;
        }

        public async Task AddRange<T>(IEnumerable<T> newEntities) where T : class, IEntity
        {
            await _dataContext.Set<T>().AddRangeAsync(newEntities);
        }

        public async Task Delete<T>(T entity) where T : class, IEntity
        {
            await Task.Run(() => _dataContext.Set<T>().Remove(entity));
        }

        public async Task DeleteRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            await Task.Run(() => _dataContext.Set<T>().RemoveRange(entities));
        }

        public async Task Update<T>(T entity) where T : class, IEntity
        {
            await Task.Run(() => _dataContext.Set<T>().Update(entity));
        }

        public async Task UpdateRange<T>(IEnumerable<T> entities) where T : class, IEntity
        {
            await Task.Run(() => _dataContext.Set<T>().UpdateRange(entities));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }
}