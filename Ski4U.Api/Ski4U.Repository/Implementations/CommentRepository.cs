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
               .Include(comment => comment.SkiItem)
               .Where(comment => comment.SkiItem.Id == skiItemId)
               .ToListAsync();
        }
    }
}
