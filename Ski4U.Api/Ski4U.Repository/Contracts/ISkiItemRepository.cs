using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface ISkiItemRepository : IRepository<SkiItem>
    {
        Task<IList<SkiItem>> GetSkiItemsByIds(IList<int> ids);
        Task<IList<SkiItem>> GetAllSkiItemsByOrderId(int orderId);
    }
}
