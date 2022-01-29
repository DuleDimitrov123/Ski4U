using System.ComponentModel.DataAnnotations.Schema;

namespace Ski4U.Data.Models
{
    public class Favorite : IEntityWithId
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int SkiItemId { get; set; }

        [ForeignKey("SkiItemId")]
        public SkiItem SkiItem { get; set; }
    }
}
