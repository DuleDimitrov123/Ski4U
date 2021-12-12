using HotChocolate;
using HotChocolate.Data;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Api.Queries
{
    public class Query
    {
        [UseSorting]
        [UseFiltering]
        public async Task<IList<SkiBoot>> GetSkiBoots([Service] ISkiBootRepository skiBootRepository)
        {
            return await skiBootRepository.GetAllSkiBoots();
        }

        [UseSorting]
        [UseFiltering]
        public async Task<SkiBoot> GetSkiBoot(int id, SkiBootBatchDataLoader dataLoader)
        {
            return await dataLoader.LoadAsync(id);
        }
    }
}
