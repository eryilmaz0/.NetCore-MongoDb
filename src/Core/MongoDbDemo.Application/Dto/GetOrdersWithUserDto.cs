using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.Application.Dto;

public class GetOrdersWithUserDto
{
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public decimal Amount { get; set; }
    public string OrderItems { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }
    public DateTime Created { get; set; }
    public ICollection<User> User { get; set; }
}