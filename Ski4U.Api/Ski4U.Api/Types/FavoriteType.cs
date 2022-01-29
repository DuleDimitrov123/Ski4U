using HotChocolate.Types;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
using System.Threading.Tasks;

namespace Ski4U.Api.Types
{
    public class FavoriteType : ObjectType<Favorite>
    {
        protected override void Configure(IObjectTypeDescriptor<Favorite> descriptor)
        {
            descriptor.Description("Represents favorite ski items for the customer");

            descriptor.Field(favorite => favorite.Customer)
                .ResolveWith<Resolvers>(favorite => favorite.GetCustomer(default!, default!))
                .Description("This is customer for the favorite");

            descriptor.Field(favorite => favorite.SkiItem)
                .ResolveWith<Resolvers>(favorite => favorite.GetSkiItem(default!, default!))
                .Description("This is the ski item for the favorite");
        }
        
        private class Resolvers
        {
            public async Task<Customer> GetCustomer(Favorite favorite, CustomerBatchDataLoader dataLoader)
            {
                return await dataLoader.LoadAsync(favorite.CustomerId);
            }

            public async Task<SkiItem> GetSkiItem(Favorite favorite, SkiItemBatchDataLoader dataLoader)
            {
                return await dataLoader.LoadAsync(favorite.SkiItemId);
            }
        }
    }
}
