using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShopEasy.Api.Products.Db;
using ShopEasy.Api.Products.Interfaces;

namespace ShopEasy.Api.Products.Providers
{
    public class ProductsProvider: IProductProvider
    {
        private readonly ProductsDbContext dbContext;
        private readonly ILogger<ProductsProvider> logger;
        private readonly IMapper mapper;

        public ProductsProvider(ProductsDbContext dbContext, ILogger<ProductsProvider> logger, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.logger = logger;
            this.mapper = mapper;

            SeedData();

        }
     
        private void SeedData()
        {
            if (!dbContext.Products.Any())
            {
                dbContext.Products.Add(new Db.Product()
                {
                    Id= 1,
                    Name="iphone 14 Pro",
                    Price=129000,
                    Inventory=100
                });
                dbContext.Products.Add(new Db.Product()
                {
                    Id = 2,
                    Name = "iphone 11 ",
                    Price = 90000,
                    Inventory = 100
                });
                dbContext.Products.Add(new Db.Product()
                {
                    Id = 3,
                    Name = "iphone 13 Pro",
                    Price = 100000,
                    Inventory = 100
                });

                dbContext.SaveChanges();
            }
        }

        public async Task<(bool IsSuccess, IEnumerable<Models.Product> Products, string ErrrMessage)> GetProductsAsync()
        {
            try
            {
                var products = await dbContext.Products.ToListAsync();
                if ( products!=null && products.Any())
                {
                    var result =mapper.Map<IEnumerable<Db.Product>, IEnumerable<Models.Product>>(products);
                    return (true, result, null);
                }
                return (false , null, "not found");
            }
            catch (Exception ex)    
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }

        public async Task<(bool IsSuccess, Models.Product Product, string ErrrMessage)> GetProductAsync(int id)
        {
            try
            {
                var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    var result = mapper.Map<Db.Product,Models.Product>(product);
                    return (true, result, null);
                }
                return (false, null, "not found");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
