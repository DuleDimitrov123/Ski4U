using HotChocolate;
using HotChocolate.Types;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Api.Types
{
    public class CustomerType : ObjectType<Customer>
    {
        protected override void Configure(IObjectTypeDescriptor<Customer> descriptor)
        {
            descriptor.Description("Represents a customer for ski items");

            descriptor.Field(c => c.Orders)
                .ResolveWith<Resolvers>(c => c.GetOrders(default!, default!))
                .Description("List of orders for the customer");

            descriptor.Field(c => c.Comments)
                .ResolveWith<Resolvers>(c => c.GetComments(default!, default!))
                .Description("List of comments for the customer");

            descriptor.Field(c => c.Favorites)
                .ResolveWith<Resolvers>(c => c.GetFavorites(default!, default!))
                .Description("List of favorites for the customer");
        }

        private class Resolvers
        {
            public async Task<IList<Order>> GetOrders(Customer customer, OrdersByCustomersGroupDataLoader dataLoader)
            {
                //return await orderRepository.GetOrdersByCustomerId(customer.Id);
                var orders = await dataLoader.LoadAsync(customer.Id);
                return orders;
            }

            public async Task<IList<Comment>> GetComments(Customer customer, CommentsByCustomersGroupedDataLoader dataLoader)
            {
                //return await commentRepository.GetAllCommentsByCustomerId(customer.Id);
                var comments = await dataLoader.LoadAsync(customer.Id);
                return comments;
            }

            public async Task<IList<Favorite>> GetFavorites(Customer customer, FavoritesByCustomerGroupedDataLoader dataLoader)
            {
                return (IList<Favorite>)await dataLoader.LoadAsync(customer.Id);
            }
        }
    }
}
