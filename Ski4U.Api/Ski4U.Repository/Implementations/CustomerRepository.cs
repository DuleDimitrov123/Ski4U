using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ski4U.Repository.Implementations
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDbContextFactory<AppDbContext> dbContextFactory)
            : base(dbContextFactory)
        {

        }

        public async Task<IList<Customer>> GetCustomersByIds(IList<int> ids)
        {
            //return await _dbSet.Include(customer => customer.Orders).Where(c => ids.Contains(c.Id)).ToListAsync();
            return await _dbSet.Where(c => ids.Contains(c.Id)).ToListAsync();
        }
    }
}
