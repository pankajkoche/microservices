
using ShopEasy.Api.Products.Models;

namespace ShopEasy.Api.Products.Interfaces
{
    public interface IProductProvider
    {
         Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrrMessage)> GetProductsAsync();
         Task<(bool IsSuccess, Product Product, string ErrrMessage)> GetProductAsync(int id);
    }
}
