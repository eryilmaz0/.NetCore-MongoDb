using MongoDbDemo.Application.Dto;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Persistence.Repository.EntityFramework;

public class EfOrderRepository : EfGenericRepository<Order, string> , IOrderRepository
{
    public Task<ICollection<GetOrdersWithUserDto>> GetOrdersWithUser()
    {
        throw new NotImplementedException();
    }
}