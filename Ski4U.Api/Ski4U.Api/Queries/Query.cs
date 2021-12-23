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
        public async Task<IList<SkiItem>> GetSkiItems([Service] ISkiItemRepository skiItemRepository)
        {
            //return await skiItemRepository.GetAllWithIncludes(item => item.SkiItemAttributes);
            return await skiItemRepository.GetAll();
        }

        [UseSorting]
        [UseFiltering]
        public async Task<SkiItem> GetSkiItem(int id, SkiItemBatchDataLoader dataLoader)
        {
            return await dataLoader.LoadAsync(id);
        }

        [UseSorting]
        [UseFiltering]
        public async Task<IList<SkiItemAttribute>> GetSkiItemAttributes([Service] ISkiItemAttributeRepository skiItemAttributeRepository)
        {
            //return await skiItemAttributeRepository.GetAllWithIncludes(attribute => attribute.SkiItem);
            return await skiItemAttributeRepository.GetAll();
        }
    }
}
