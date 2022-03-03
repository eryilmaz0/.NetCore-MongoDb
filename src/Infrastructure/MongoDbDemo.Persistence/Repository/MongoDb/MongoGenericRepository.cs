using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDbDemo.Application.Interfaces.Context;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Domain.Common;

namespace MongoDbDemo.Persistence.Repository.MongoDb;

public class MongoGenericRepository<TEntity, TPrimaryKey> : IGenericRepository<TEntity, TPrimaryKey> 
                                                            where TEntity: class, IEntity<TPrimaryKey>
{
    private readonly IMongoDbContext _context;
    private IMongoCollection<TEntity> _collection;

    public MongoGenericRepository(IMongoDbContext context)
    {
        _context = context;
        _collection = _context.GetCollection<TEntity>(typeof(TEntity).Name);
    }



    public async Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
    {
        if (filter is null)
            return await _collection.Find(x => true).ToListAsync();

        return  await _collection.Find(filter).ToListAsync();
    }


    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
    {
        return await _collection.Find(filter).FirstOrDefaultAsync();
    }


    public async Task Insert(TEntity entity)
    {
        await _collection.InsertOneAsync(entity);
    }


    public async Task Delete(TEntity entity)
    {
        await _collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
    }


    public async Task Update(TEntity entity)
    {
        await _collection.FindOneAndReplaceAsync(x => x.Id.Equals(entity.Id), entity);
    }
}