using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IList<Comment>> GetAllCommentsBySkiItemId(int skiItemId);
    }
}
