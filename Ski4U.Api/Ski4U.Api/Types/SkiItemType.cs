using HotChocolate;
using HotChocolate.Types;
using Ski4U.Data.Models;
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
        }

        private class Resolvers
        {
            public async Task<IList<SkiItemAttribute>> GetSkiItemAttributes(SkiItem item, [Service] ISkiItemAttributeRepository repository)
            {
                return await repository.GetAllSkiItemAttributesBySkiItemId(item.Id);
            }
        }
    }
}
