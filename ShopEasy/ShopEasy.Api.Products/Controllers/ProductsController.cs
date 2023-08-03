using Microsoft.AspNetCore.Mvc;
using ShopEasy.Api.Products.Interfaces;

namespace ShopEasy.Api.Products.Controllers
{
    [ApiController]

    [Route("api/Products")]
    public class ProductsController: ControllerBase
    {
        private readonly IProductProvider productProvider;
        public ProductsController(IProductProvider productsProvider)
        {
            this.productProvider = productsProvider;

        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
           var result = await productProvider.GetProductsAsync();
            if (result.IsSuccess)
            {
                return Ok(result.Products);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var result = await productProvider.GetProductAsync(id);
            if (result.IsSuccess)
            {
                return Ok(result.Product);
            }
            return NotFound();

        }
        
    }
}
