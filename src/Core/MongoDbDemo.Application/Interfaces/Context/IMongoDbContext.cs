using MongoDB.Driver;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Application.Interfaces.Context;

public interface IMongoDbContext
{
    IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName) where TEntity : class;
}