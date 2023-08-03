using Microsoft.EntityFrameworkCore;

namespace ShopEasy.Api.Orders.Db
{
    public class OrdersDbContext:DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public OrdersDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
