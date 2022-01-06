using HotChocolate.Types;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
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
                .Description("This is the ski item to which the ski item attribute belongs");
        }

        private class Resolvers
        {
            public async Task<SkiItem> GetSkiItem(Comment comment, SkiItemBatchDataLoader dataLoader)
            {
                return await dataLoader.LoadAsync(comment.SkiItem.Id);
            }
        }
    }
}
