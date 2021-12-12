using GreenDonut;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.DataLoader.DataLoaders
{
    public class SkiBootBatchDataLoader : BatchDataLoader<int, SkiBoot>
    {
        private readonly ISkiBootRepository _skiBootRepository;

        public SkiBootBatchDataLoader(
            ISkiBootRepository skiBootRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            :base(batchScheduler, options)
        {
            _skiBootRepository = skiBootRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, SkiBoot>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            //insead of fetching one SkiBoot, we fetch multiple SkiBoots
            var skiBoots = await _skiBootRepository.GetSkiBootByIds((IList<int>)keys);
            return skiBoots.ToDictionary(s => s.Id);
        }
    }
}
