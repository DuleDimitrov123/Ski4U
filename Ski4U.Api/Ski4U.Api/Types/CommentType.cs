using HotChocolate;
using HotChocolate.Types;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
using Ski4U.Repository.Contracts;
using System.Threading.Tasks;

namespace Ski4U.Api.Types
{
    public class CommentType : ObjectType<Comment>
    {
        protected override void Configure(IObjectTypeDescriptor<Comment> descriptor)
        {
            descriptor.Description("Represents comment for ski item");

            descriptor.Field(comment => comment.SkiItem)
                .ResolveWith<Resolvers>(comment => comment.GetSkiItem(default!, default!))
                .Description("This is the ski item to which the comment belongs");

            descriptor.Field(comment => comment.Customer)
                .ResolveWith<Resolvers>(comment => comment.GetCustomer(default!, default!))
                .Description("Customer for the comment");
        }

        private class Resolvers
        {
            public async Task<SkiItem> GetSkiItem(Comment comment, SkiItemBatchDataLoader dataLoader)
            {
                return await dataLoader.LoadAsync(comment.SkiItem.Id);
            }

            public async Task<Customer> GetCustomer(Comment comment, CustomerBatchDataLoader dataLoader)
            {
                //return await customerRepository.GetOne(comment.CustomerId);
                return await dataLoader.LoadAsync(comment.CustomerId);
            }
        }
    }
}
