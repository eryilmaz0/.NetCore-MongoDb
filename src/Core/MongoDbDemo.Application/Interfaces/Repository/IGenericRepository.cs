using System.Linq.Expressions;
using MongoDbDemo.Domain.Common;

namespace MongoDbDemo.Application.Interfaces.Repository;

public interface IGenericRepository<TEntity, TPrimaryKey> where  TEntity : IEntity<TPrimaryKey>
{
    Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
    Task Insert(TEntity entity);
    Task Delete(TEntity entity);
    Task Update(TEntity entity);
}