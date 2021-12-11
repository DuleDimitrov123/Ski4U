using HotChocolate;
using HotChocolate.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Api.Queries
{
    public class QuerySkiBoot
    {
        [UseSorting]
        [UseFiltering]
        public async Task<IList<SkiBoot>> GetSkyBoots([Service] ISkiBootRepository skiBootRepository)
        {
            return await skiBootRepository.GetAllSkiBoots();
        }
    }
}
