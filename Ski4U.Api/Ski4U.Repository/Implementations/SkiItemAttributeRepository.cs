using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ski4U.Repository.Implementations
{
    public class SkiItemAttributeRepository : Repository<SkiItemAttribute>, ISkiItemAttributeRepository
    {
        public SkiItemAttributeRepository(IDbContextFactory<AppDbContext> dbContextFactory)
            : base(dbContextFactory)
        {

        }

        public async Task<IList<SkiItemAttribute>> GetAllSkiItemAttributesBySkiItemId(int skiItemId)
        {
            return await _dbSet
                .Include(attribute => attribute.SkiItem)
                .Where(attribute => attribute.SkiItem.Id == skiItemId)
                .ToListAsync();
        }
    }
}
