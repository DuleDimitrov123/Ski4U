using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ski4U.Data.Models
{
    public class Order : IEntityWithId
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public IList<SkiItem> SkiItems { get; set; } = new List<SkiItem>();

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
