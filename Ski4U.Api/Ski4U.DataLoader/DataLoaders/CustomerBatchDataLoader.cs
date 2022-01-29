using GreenDonut;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.DataLoader.DataLoaders
{
    public class CustomerBatchDataLoader : BatchDataLoader<int, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerBatchDataLoader(
            ICustomerRepository customerRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            : base(batchScheduler, options)
        {
            _customerRepository = customerRepository;
        }

        protected override async Task<IReadOnlyDictionary<int, Customer>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersByIds((IList<int>)keys);
            return customers.ToDictionary(c => c.Id);
        }
    }
}
