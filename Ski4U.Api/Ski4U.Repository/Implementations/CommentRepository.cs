using Microsoft.EntityFrameworkCore;
using Ski4U.Data;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ski4U.Repository.Implementations
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(IDbContextFactory<AppDbContext> dbContextFactory)
           : base(dbContextFactory)
        {
        }

        public async Task<IList<Comment>> GetAllCommentsBySkiItemId(int skiItemId)
        {
            return await _dbSet
               .Where(comment => comment.SkiItemId == skiItemId)
               .ToListAsync();
        }

        public async Task<IList<Comment>> GetAllCommentsByCustomerId(int customerId)
        {
            return await _dbSet
                .Where(comment => comment.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IList<Comment>> GetAllCommentsByCustomerIds(IList<int> customerIds)
        {
            return await _dbSet
                .Where(comment => customerIds.Contains(comment.CustomerId))
                .ToListAsync();
        }
    }
}
