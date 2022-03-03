using Microsoft.Extensions.DependencyInjection;
using MongoDbDemo.Application.Interfaces.Context;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Persistence.Context;
using MongoDbDemo.Persistence.Repository.EntityFramework;
using MongoDbDemo.Persistence.Repository.MongoDb;

namespace MongoDbDemo.Persistence;

public static class ServiceRegistration
{
    public static void RegisterPersistenceServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddTransient(typeof(IGenericRepository<,>), typeof(MongoGenericRepository<,>));
        serviceCollection.AddTransient<IUserRepository, MongoUserRepository>();
        serviceCollection.AddTransient<IOrderRepository, MongoOrderRepository>();
        serviceCollection.AddTransient<IMongoDbContext, MongoDbContext>();
    }
}