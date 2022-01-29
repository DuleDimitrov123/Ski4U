using GreenDonut;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.DataLoader.DataLoaders
{
    public class OrderBatchDataLoader : BatchDataLoader<int, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public OrderBatchDataLoader(
            IOrderRepository orderRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            : base(batchScheduler, options)
        {
            _orderRepository = orderRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, Order>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetOrdersByIds((IList<int>)keys);
            return orders.ToDictionary(o => o.Id);
        }
    }
}
