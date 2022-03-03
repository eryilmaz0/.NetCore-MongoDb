using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDbDemo.Application.Configuration;
using MongoDbDemo.Application.Interfaces.Context;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Persistence.Context;

public class MongoDbContext : IMongoDbContext
{
    private readonly IMongoClient _client;
    private readonly IMongoDatabase _mongoDb;
    private readonly MongoDbContextOptions _config;

    public MongoDbContext(IOptions<MongoDbContextOptions> config)
    {
        _config = config.Value;
        _client = new MongoClient(_config.ConnectionString);
        _mongoDb = _client.GetDatabase(_config.DatabaseName);
    }


    public IMongoCollection<TEntity> GetCollection<TEntity>(string collectionName) where TEntity : class
    {
        return _mongoDb.GetCollection<TEntity>(collectionName);
    }
}