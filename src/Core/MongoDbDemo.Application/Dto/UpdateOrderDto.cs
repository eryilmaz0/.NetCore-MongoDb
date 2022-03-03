namespace MongoDbDemo.Application.Dto;

public class UpdateOrderDto
{
    public string OrderId { get; set; }
    public string OrderItems { get; set; }
    public decimal Amount { get; set; }
}