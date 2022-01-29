using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ski4U.Api.Models
{
    public class OrderModels
    {
        public record AddOrderRequest(IList<int> Ids, int CustomerId);

        public record AddNewSkiItemToOrderRequest(int OrderId, int SkiItemId);
    }
}
