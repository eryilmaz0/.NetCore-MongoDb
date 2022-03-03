namespace MongoDbDemo.Domain.Common;

public interface IEntity<TPrimaryKey>
{
     TPrimaryKey Id { get; set; }
     DateTime Created { get; set; }
}