using MongoDB.Driver;
using MongoDbDemo.Application.Dto;
using MongoDbDemo.Application.Interfaces.Context;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Persistence.Repository.MongoDb;

public class MongoUserRepository : MongoGenericRepository<User, string>, IUserRepository
{
    private readonly IMongoDbContext _context;
    private readonly IMongoCollection<User> _collection;

    public MongoUserRepository(IMongoDbContext context) : base(context)
    {
        _context = context;
        _collection = _context.GetCollection<User>(typeof(User).Name);
    }

    //Custom Operations
    public async Task<ICollection<GetUsersWithOrdersDto>> GetUsersWithOrders()
    {
        var result = _collection.Aggregate<User>().Lookup<User, Order, GetUsersWithOrdersDto>(_context.GetCollection<Order>("Order"),
            fromType => fromType.Id, targetType => targetType.UserId, outputType => outputType.Orders).ToListAsync();

        return await result;
    }
}