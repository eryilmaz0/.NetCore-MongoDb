using System.Linq.Expressions;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Domain.Common;

namespace MongoDbDemo.Persistence.Repository.EntityFramework;

public class EfGenericRepository<TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
{
    public Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task Insert(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(TEntity entity)
    {
        throw new NotImplementedException();
    }
}