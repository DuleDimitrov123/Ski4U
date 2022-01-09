using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ski4U.Repository.Implementations
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(IDbContextFactory<AppDbContext> dbContextFactory)
          : base(dbContextFactory)
        {

        }

        public async Task<IList<Order>> GetOrdersByIds(IList<int> ids)
        {
            return await _dbSet
                .Include(order => order.SkiItems)
                .Where(o => ids.Contains(o.Id))
                .ToListAsync();
        }
    }
}
