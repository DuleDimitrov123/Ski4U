using GreenDonut;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ski4U.DataLoader.DataLoaders
{
    public class CommentsByCustomersGroupedDataLoader : GroupedDataLoader<int, Comment>
    {
        private readonly ICommentRepository _commentRepository;

        public CommentsByCustomersGroupedDataLoader(
            ICommentRepository commentRepository,
            IBatchScheduler batchScheduler,
            DataLoaderOptions options = null)
            : base(batchScheduler, options)
        {
            _commentRepository = commentRepository;
        }

        protected override async Task<ILookup<int, Comment>> LoadGroupedBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            var comments = await _commentRepository.GetAllCommentsByCustomerIds((IList<int>)keys);
            return comments.ToLookup(comment => comment.CustomerId);
        }
    }
}
