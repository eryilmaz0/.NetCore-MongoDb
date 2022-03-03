using MongoDB.Bson.Serialization.Attributes;
using MongoDbDemo.Domain.Common;

namespace MongoDbDemo.Domain.Entity;

public class User : MongoEntityBase<string>
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Address Address { get; set; }
    
    [BsonIgnore] 
    public List<Order> Orders { get; set; }

    public User()
    {
        this.Orders = new();
    }
}