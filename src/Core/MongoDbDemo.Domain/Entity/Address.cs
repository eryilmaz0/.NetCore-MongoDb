using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbDemo.Domain.Common;

namespace MongoDbDemo.Domain.Entity;

public class Address : MongoEntityBase<string>
{
    public string Country { get; set; }
    public string City { get; set; }
    public string FullAddress { get; set; }
}