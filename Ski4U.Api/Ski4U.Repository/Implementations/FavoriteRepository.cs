using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ski4U.Repository.Implementations
{
    public class FavoriteRepository : Repository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(IDbContextFactory<AppDbContext> dbContextFactory)
            : base(dbContextFactory)
        {

        }

        public async Task<IList<Favorite>> GetFavoritesByIds(IList<int> favoriteIds)
        {
            return await _dbSet
                .Where(favorite => favoriteIds.Contains(favorite.Id))
                .ToListAsync();
        }

        public async Task<IList<Favorite>> GetFavoritesByCustomerId(int customerId)
        {
            return await _dbSet
                .Where(favorite => favorite.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IList<Favorite>> GetFavoritesByCustomerIds(IList<int> customerIds)
        {
            return await _dbSet
                .Where(favorite => customerIds.Contains(favorite.CustomerId))
                .ToListAsync();
        }

        public async Task<IList<Favorite>> GetFavoritesBySkiItemsIds(IList<int> skiItemIds)
        {
            return await _dbSet
                .Where(favorite => skiItemIds.Contains(favorite.SkiItemId))
                .ToListAsync();
        }
    }
}
