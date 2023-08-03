using Microsoft.AspNetCore.Mvc;
using ShopEasy.Api.Customers.Interfaces;

namespace ShopEasy.Api.Customers.Controllers
{
    [ApiController]

    [Route("api/Customers")]
    public class CustomersControllers : ControllerBase
    {
        private readonly ICustomersProvider customersProvider;
        public CustomersControllers(ICustomersProvider customersProvider)
        {
            this.customersProvider = customersProvider;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersAsync()
        {
            var result = await customersProvider.GetCustomersAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerAsync(int id)
        {
            var result = await customersProvider.GetCustomerAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Customers);
            }
            return NotFound();
        }
    }
}
