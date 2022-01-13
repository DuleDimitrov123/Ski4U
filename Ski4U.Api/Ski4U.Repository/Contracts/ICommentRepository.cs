using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IList<Comment>> GetAllCommentsBySkiItemId(int skiItemId);

        Task<IList<Comment>> GetAllCommentsByCustomerId(int customerId);

        Task<IList<Comment>> GetAllCommentsByCustomerIds(IList<int> customerIds);
    }
}
