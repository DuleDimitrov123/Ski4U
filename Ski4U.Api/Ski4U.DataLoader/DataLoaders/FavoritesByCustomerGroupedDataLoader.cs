using GreenDonut;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.DataLoader.DataLoaders
{
    public class FavoritesByCustomerGroupedDataLoader : GroupedDataLoader<int, Favorite>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoritesByCustomerGroupedDataLoader(
            IFavoriteRepository favoriteRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            : base(batchScheduler, options)
        {
            _favoriteRepository = favoriteRepository;
        }
        protected override async Task<ILookup<int, Favorite>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var favorites = await _favoriteRepository.GetFavoritesByCustomerIds((IList<int>)keys);
            return favorites.ToLookup(favorite => favorite.CustomerId);
        }
    }
}
