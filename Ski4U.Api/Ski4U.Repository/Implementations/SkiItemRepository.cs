using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.Repository.Implementations
{
    public class SkiItemRepository : Repository<SkiItem>, ISkiItemRepository
    {

        public SkiItemRepository(IDbContextFactory<AppDbContext> dbContextFactory)
            : base(dbContextFactory)
        {
        }

        /*public async Task<IList<SkiItem>> GetAllSkiItems()
        {
            return await _context.SkiItems.Include(item => item.SkiItemAttributes).ToListAsync();
        }*/

        public async Task<IList<SkiItem>> GetSkiItemsByIds(IList<int> ids)
        {
            return await _dbSet.Include(item => item.SkiItemAttributes).Where(s => ids.Contains(s.Id)).ToListAsync();
        }

        /*public async Task<SkiItem> AddSkiItem(SkiItem skiItem, CancellationToken cancellationToken)
        {
            _context.SkiItems.Add(skiItem);

            await _context.SaveChangesAsync(cancellationToken);

            return skiItem;
        }*/
    }
}
