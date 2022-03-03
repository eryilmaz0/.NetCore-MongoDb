using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbDemo.Domain.Common;

public class MongoEntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public TPrimaryKey Id { get; set; }
    
    public DateTime Created { get; set; }


    public MongoEntityBase()
    {
        this.Created = DateTime.Now;
    }
}