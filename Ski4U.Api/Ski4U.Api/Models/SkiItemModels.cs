using Ski4U.Data;
using System.Collections.Generic;

namespace Ski4U.Api.Models
{
    public class SkiItemModels
    {
        public record SkiItemAttributeRequestResponse(string Name, string Value);

        public record AddSkiItemRequest(double Price, Sex Sex, string Name, int Season, bool IsNew, string Color, IList<SkiItemAttributeRequestResponse> SkiItemAttributesRequestResponse);

        public record UpdateSkiItemRequest(int Id, double Price, Sex Sex, string Name, int Season, bool IsNew, string Color);
    }
}
