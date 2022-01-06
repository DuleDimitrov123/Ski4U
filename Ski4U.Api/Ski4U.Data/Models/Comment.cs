namespace Ski4U.Data.Models
{
    public class Comment : IEntityWithId
    {
        public int Id { get; set; }

        public string CommentText { get; set; }

        public int SkiItemId { get; set; }

        public SkiItem SkiItem { get; set; }

        // public Customer Customer { get; set; }
    }
}
