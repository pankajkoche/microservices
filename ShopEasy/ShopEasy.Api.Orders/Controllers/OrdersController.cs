using Microsoft.AspNetCore.Mvc;
using ShopEasy.Api.Orders.Interfaces;

namespace ShopEasy.Api.Orders.Controllers
{
    [ApiController]
    [Route("api/Orders")]
    public class OrdersController:ControllerBase
    {
        private readonly IOrdersProvider ordersProvider;
        public OrdersController(IOrdersProvider ordersProvider)
        {
            this.ordersProvider = ordersProvider;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetOrdersAsync(int customerId)
        {
            var result = await ordersProvider.GetOrdersAsync(customerId);
            if(result.IsSuccess)
            {
                return Ok(result.Orders);
            }
            return NotFound();
        }
    }
}
