using System.Security.AccessControl;

namespace MongoDbDemo.Application.Dto;

public class CreateAddressDto
{
    public string Country { get; set; }
    public string City { get; set; }
    public string FullAddress { get; set; }
};