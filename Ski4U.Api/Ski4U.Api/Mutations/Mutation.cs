using HotChocolate;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Threading;
using System.Threading.Tasks;
using static Ski4U.Api.Models.SkiBootModels;

namespace Ski4U.Api.Mutations
{
    public class Mutation
    {
        public async Task<SkiBoot> AddSkiBoot(AddSkiBootRequest input, [Service] ISkiBootRepository skiBootRepository, CancellationToken cancellationToken)
        {
            return await skiBootRepository.AddSkiBoot(
                new SkiBoot
                {
                    Price = input.Price,
                    Sex = input.Sex,
                    Season = input.Season,
                    IsNew = input.IsNew,
                    Color = input.Color,
                    SkiBootSize = input.SkiBootSize,
                    SkiBootFlex = input.SkiBootFlex
                }, cancellationToken);
        }
    }
}
