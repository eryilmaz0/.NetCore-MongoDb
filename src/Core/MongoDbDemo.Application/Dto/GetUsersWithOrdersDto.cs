using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Application.Dto;

public class GetUsersWithOrdersDto
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Address Address { get; set; }
    public DateTime Created { get; set; }

    public ICollection<Order> Orders { get; set; }
}