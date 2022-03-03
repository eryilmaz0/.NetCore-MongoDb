using MongoDbDemo.Application.Dto;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Application.Interfaces.Repository;

public interface IOrderRepository : IGenericRepository<Order, string>
{
    public Task<ICollection<GetOrdersWithUserDto>> GetOrdersWithUser();
}