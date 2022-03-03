using MongoDbDemo.Application.Dto;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Persistence.Repository.EntityFramework;

public class EfUserRepository : EfGenericRepository<User, string> , IUserRepository
{
    public Task<ICollection<GetUsersWithOrdersDto>> GetUsersWithOrders()
    {
        throw new NotImplementedException();
    }
}