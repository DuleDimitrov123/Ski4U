using HotChocolate;
using HotChocolate.Types;
using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Api.Types
{
    public class CustomerType : ObjectType<Customer>
    {
        //This should be added after we implement logic for orders (repository, dataloaders...)
        /*protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Description("Represents a customer for ski items");

            descriptor.Field(c => c.Orders)
                .ResolveWith<Reso>
        }

        private class Resolvers
        {
            public async Task<IList<Order>> GetOrders(Order order, [Service] IOrderRepository orderRepository)
            {
                return null;
            }
        }*/
    }
}
