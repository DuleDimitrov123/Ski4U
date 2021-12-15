using HotChocolate;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Ski4U.Api.Models.SkiItemModels;

namespace Ski4U.Api.Mutations
{
    public class Mutation
    {
        public async Task<SkiItem> AddSkiItem(AddSkiItemRequest input, [Service] ISkiItemRepository skiBootRepository, CancellationToken cancellationToken)
        {
            var skiItem = new SkiItem
            {
                Price = input.Price,
                Sex = input.Sex,
                Name = input.Name,
                Season = input.Season,
                IsNew = input.IsNew,
                Color = input.Color
            };

            foreach (var item in input.SkiItemAttributesRequestResponse)
            {
                skiItem.SkiItemAttributes.Add(new SkiItemAttribute
                {
                    SkiItem = skiItem,
                    Name = item.Name,
                    Value = item.Value
                });
            }

            return await skiBootRepository.Add(skiItem);
        }
    }
}
