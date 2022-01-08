using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ski4U.Api.Models
{
    public class OrderModels
    {
        public record UpdateOrderRequest(int orderId, int skiItemId);
    }
}
