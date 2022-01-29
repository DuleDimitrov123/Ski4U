using GreenDonut;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.DataLoader.DataLoaders
{
    public class SkiItemBatchDataLoader : BatchDataLoader<int, SkiItem>
    {
        private readonly ISkiItemRepository _skiItemRepository;

        public SkiItemBatchDataLoader(
            ISkiItemRepository skiItemRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            : base(batchScheduler, options)
        {
            _skiItemRepository = skiItemRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, SkiItem>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            //insead of fetching one SkiItem, we fetch multiple SkiItems
            var skiItems = await _skiItemRepository.GetSkiItemsByIds((IList<int>)keys);
            return skiItems.ToDictionary(s => s.Id);
        }
    }
}
