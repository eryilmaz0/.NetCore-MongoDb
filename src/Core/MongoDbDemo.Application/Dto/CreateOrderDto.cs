namespace MongoDbDemo.Application.Dto;

public class CreateOrderDto
{
    public decimal Amount { get; set; }
    public string OrderItems { get; set; }
    public string UserId { get; set; }
}