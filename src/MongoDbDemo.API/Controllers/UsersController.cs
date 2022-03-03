using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Application.Dto;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _userRepository.GetAllAsync());
        }


        [HttpGet]
        [Route("WithOrders")]
        public async Task<IActionResult> GetUsersWithOrders()
        {
            return Ok(await _userRepository.GetUsersWithOrders());
        }


        [HttpGet]
        [Route("{userId}")]
        public async Task<IActionResult> GetUser([FromRoute] string userId)
        {
            return Ok(await _userRepository.GetAsync(x => x.Id == userId));
        }


        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto request)
        {
            User user = new()
            {
                Name = request.Name,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                Address = new() {City = request.Address.City, Country = request.Address.Country, FullAddress = request.Address.FullAddress }
            };

            await _userRepository.Insert(user);

            return Ok("User Created.");    
        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto request)
        {
            var user = await _userRepository.GetAsync(x => x.Id == request.userId);

            if (user is null)
                return BadRequest("User Not Found.");

            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Address = new() { City = request.address.City, Country = request.address.Country, FullAddress = request.address.FullAddress };

            await _userRepository.Update(user);
            return Ok("User Updated.");
        }


        [HttpDelete]
        [Route("{userId}")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userRepository.GetAsync(x => x.Id == userId);

            if (user is null)
                return BadRequest("User Not Found.");

            await _userRepository.Delete(user);

            return Ok("User Deleted.");
        }
    }
}
