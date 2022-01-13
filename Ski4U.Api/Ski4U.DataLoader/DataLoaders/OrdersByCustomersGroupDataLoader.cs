using GreenDonut;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.DataLoader.DataLoaders
{
    public class OrdersByCustomersGroupDataLoader : GroupedDataLoader<int, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersByCustomersGroupDataLoader(
            IOrderRepository orderRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            : base(batchScheduler, options)
        {
            _orderRepository = orderRepository;
        }

        protected override async Task<ILookup<int, Order>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByCustomerIds((IList<int>)keys);
            return orders.ToLookup(o => o.CustomerId);
        }
    }
}
