using MongoDB.Driver;
using MongoDbDemo.Application.Dto;
using MongoDbDemo.Application.Interfaces.Context;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Persistence.Repository.MongoDb;

public class MongoOrderRepository : MongoGenericRepository<Order, string> , IOrderRepository
{
    private readonly IMongoDbContext _context;
    private readonly IMongoCollection<Order> _collection;
    public MongoOrderRepository(IMongoDbContext context) : base(context)
    {
        _context = context;
        _collection = _context.GetCollection<Order>(typeof(Order).Name);
    }
    
    
    //Custom Operations
    public async Task<ICollection<GetOrdersWithUserDto>> GetOrdersWithUser()
    {
        var result = _collection.Aggregate<Order>().Lookup<Order, User, GetOrdersWithUserDto>(_context.GetCollection<User>("User"),
                                 fromType => fromType.UserId, targetType => targetType.Id, outputType => outputType.User).ToListAsync();

        return await result;
    }
}