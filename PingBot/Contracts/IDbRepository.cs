using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PingBot.Contracts.Entities;

namespace PingBot.Contracts
{
    public interface IDbRepository
    {
        IQueryable<T> Get<T>() where T : class,IEntity;
        IQueryable<T> GetAll<T>() where T : class, IEntity;
        Task<uint> Add<T>(T newEntity) where T : class, IEntity;
        Task AddRange<T>(IEnumerable<T> newEntities) where T: class, IEntity;
        Task  Delete<T>(uint Id) where T : class, IEntity;
        Task Remove <T>(T entity) where T : class;
        Task DeleteRange<T>(IEnumerable<T> entities) where T: class, IEntity;
        Task Update<T>(T entity) where T: class, IEntity;
        Task UpdateRange<T>(IEnumerable<T> entities) where T: class, IEntity;
        Task<int> SaveChangesAsync();
    }
}