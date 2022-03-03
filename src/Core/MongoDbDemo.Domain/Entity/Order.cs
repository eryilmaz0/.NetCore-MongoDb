using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbDemo.Domain.Common;

namespace MongoDbDemo.Domain.Entity;

public class Order : MongoEntityBase<string>
{
    public decimal Amount { get; set; }
    public string OrderItems { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string UserId { get; set; }

    [BsonIgnore]
    public User User { get; set; }
}