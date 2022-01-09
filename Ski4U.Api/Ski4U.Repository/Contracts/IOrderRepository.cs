using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IList<Order>> GetOrdersByIds(IList<int> ids);
    }
}
