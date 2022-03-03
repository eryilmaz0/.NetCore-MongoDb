namespace MongoDbDemo.Application.Dto;

public class CreateUserDto
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public CreateAddressDto Address { get; set; }
}