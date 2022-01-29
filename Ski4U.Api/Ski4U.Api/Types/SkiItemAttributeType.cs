using HotChocolate.Types;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
using System.Threading.Tasks;

namespace Ski4U.Api.Types
{
    public class SkiItemAttributeType : ObjectType<SkiItemAttribute>
    {
        protected override void Configure(IObjectTypeDescriptor<SkiItemAttribute> descriptor)
        {
            descriptor.Description("Represents ski item attributes");

            descriptor.Field(sia => sia.SkiItem)
                .ResolveWith<Resolvers>(sia => sia.GetSkiItem(default!, default!))
                .Description("This is the ski item to which the ski item attribute belongs");
        }

        private class Resolvers
        {
            public async Task<SkiItem> GetSkiItem(SkiItemAttribute skiItemAttribute, SkiItemBatchDataLoader dataLoader)
            {
                var skiItem = await dataLoader.LoadAsync(skiItemAttribute.SkiItem.Id);
                return skiItem;
            }
        }
    }
}
