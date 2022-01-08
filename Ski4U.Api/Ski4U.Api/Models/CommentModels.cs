using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ski4U.Api.Models
{
    public class CommentModels
    {
        public record AddCommentRequest(string CommentText, int SkiItemId);

        public record UpdateCommentRequest(string CommentText, int CommentId);
    }
}
