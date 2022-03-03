using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDbDemo.Application.Dto;
using MongoDbDemo.Application.Interfaces.Context;
using MongoDbDemo.Application.Interfaces.Repository;
using MongoDbDemo.Domain.Entity;

namespace MongoDbDemo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _orderRepository.GetAllAsync());
        }


        [HttpGet]
        [Route("WithUser")]
        public async Task<IActionResult> GetOrdersWithUser()
        {
            return Ok(await _orderRepository.GetOrdersWithUser());
        }


        [HttpGet]
        [Route("{orderId}")]
        public async Task<IActionResult> GetOrder([FromRoute] string orderId)
        {
            var order = await _orderRepository.GetAsync(x => x.Id == orderId);

            if (order is null)
                return BadRequest("Order Not Found.");

            return Ok(order);
        }


        [HttpGet]
        [Route("ByUser/{userId}")]
        public async Task<IActionResult> GetOrdersByUser([FromRoute] string userId)
        {
            var orders = await _orderRepository.GetAllAsync(x => x.UserId == userId);

            if (orders is null || !orders.Any())
                return BadRequest("Order Not Found.");

            return Ok(orders);
        }


        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto request)
        {
            Order order = new()
            {
                Amount = request.Amount,
                OrderItems = request.OrderItems,
                UserId = request.UserId
            };

            await _orderRepository.Insert(order);
            return Ok("Order Created.");
        }



        [HttpPut]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderDto request)
        {
            var order = await _orderRepository.GetAsync(x => x.Id == request.OrderId);

            if (order is null)
                return BadRequest("Order Not Found.");

            order.Amount = request.Amount;
            order.OrderItems = request.OrderItems;

            await _orderRepository.Update(order);
            return Ok("Order Updated.");
        }


        [HttpDelete]
        [Route("{orderId}")]
        public async Task<IActionResult> DeleteOrder(string orderId)
        {
            var order = await _orderRepository.GetAsync(x => x.Id == orderId);

            if (order is null)
                return BadRequest("Order Not Found.");

            await _orderRepository.Delete(order);
            return Ok("Order Deleted.");
        }

    }
}
