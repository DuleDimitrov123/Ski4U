using HotChocolate;
using HotChocolate.Types;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Api.Types
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.Description("Represents order with ski items (one or more)");

            descriptor.Field(order => order.SkiItems)
                .ResolveWith<Resolvers>(order => order.GetSkiItems(default!, default!))
                .Description("List of one or more ski items that were in order");

            descriptor.Field(order => order.Price)
                .Description("Total price of order (updates every time new ski item is added)");
        }

        private class Resolvers
        {
            public async Task<IList<SkiItem>> GetSkiItems(Order order, [Service] ISkiItemRepository repository)
            {
                return await repository.GetAllSkiItemsByOrderId(order.Id);
            }
        }
    }
}
