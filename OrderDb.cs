using Microsoft.EntityFrameworkCore;

namespace CRUD_order
{
    public class OrderDb : DbContext
    {
        public OrderDb(DbContextOptions<OrderDb> options) : base(options) { }
        public DbSet<Order> Orders => Set<Order>();
    }
}
