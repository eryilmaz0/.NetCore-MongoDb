using MongoDbDemo.Application.Dto;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Application.Interfaces.Repository;

public interface IUserRepository : IGenericRepository<User, string>
{
    public Task<ICollection<GetUsersWithOrdersDto>> GetUsersWithOrders();
}