using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;

namespace Ski4U.Repository.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDbContextFactory<AppDbContext> dbContextFactory)
          : base(dbContextFactory)
        {
        }
    }
}
