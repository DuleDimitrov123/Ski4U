using GreenDonut;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.DataLoader.DataLoaders
{
    public class FavoritesBatchDataLoader : BatchDataLoader<int, Favorite>
    {
        private readonly IFavoriteRepository _favoriteRepository;

        public FavoritesBatchDataLoader(
            IFavoriteRepository favoriteRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            : base(batchScheduler, options)
        {
            _favoriteRepository = favoriteRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, Favorite>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var favorites = await _favoriteRepository.GetFavoritesByIds((IList<int>)keys);
            return favorites.ToDictionary(favorite => favorite.Id);
        }
    }
}
