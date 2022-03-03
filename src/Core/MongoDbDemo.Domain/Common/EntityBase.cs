namespace MongoDbDemo.Domain.Common;

public class EntityBase<TPrimaryKey> : IEntity<TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }
    public DateTime Created { get; set; }
}