namespace MongoDbDemo.Application.Dto;

public record UpdateUserDto(string userId, string Name, string LastName, UpdateAddressDto address);