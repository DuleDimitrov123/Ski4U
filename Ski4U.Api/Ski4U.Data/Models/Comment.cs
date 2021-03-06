using System.ComponentModel.DataAnnotations.Schema;

namespace Ski4U.Data.Models
{
    public class Comment : IEntityWithId
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public int SkiItemId { get; set; }

        [ForeignKey("SkiItemId")]
        public SkiItem SkiItem { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
