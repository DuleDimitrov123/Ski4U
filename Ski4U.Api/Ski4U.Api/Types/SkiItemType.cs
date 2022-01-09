using GreenDonut;
using HotChocolate;
using HotChocolate.Types;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Api.Types
{
    public class SkiItemType : ObjectType<SkiItem>
    {
        protected override void Configure(IObjectTypeDescriptor<SkiItem> descriptor)
        {
            descriptor.Description("Represents a ski item");

            descriptor.Field(si => si.SkiItemAttributes)
                .ResolveWith<Resolvers>(si => si.GetSkiItemAttributes(default!, default!))
                .Description("List of ski item attributes to describe better the ski item");

            descriptor.Field(si => si.Comments)
                .ResolveWith<Resolvers>(si => si.GetComments(default!, default!))
                .Description("List of comments that customers left for certain ski item.");

            descriptor.Field(si => si.Order)
               .ResolveWith<Resolvers>(si => si.GetOrder(default!, default!))
               .Description("This is order that this ski item belongs to.");
        }

        private class Resolvers
        {
            public async Task<IList<SkiItemAttribute>> GetSkiItemAttributes(SkiItem item, [Service] ISkiItemAttributeRepository repository)
            {
                return await repository.GetAllSkiItemAttributesBySkiItemId(item.Id);
            }

            public async Task<IList<Comment>> GetComments(SkiItem item, [Service] ICommentRepository repository)
            {
                return await repository.GetAllCommentsBySkiItemId(item.Id);
            }

            public async Task<Order> GetOrder(SkiItem skiItem, OrderBatchDataLoader dataLoader)
            {
                return (Order)await dataLoader.LoadAsync(skiItem.OrderId);
            }
        }
    }
}
