using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<IList<Customer>> GetCustomersByIds(IList<int> ids);
    }
}
