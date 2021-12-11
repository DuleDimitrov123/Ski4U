using System.ComponentModel.DataAnnotations;

namespace Ski4U.Data.Models
{
    public class SkiItem
    {
        [Key]
        public int Id { get; set; }

        public double Price { get; set; }

        public Sex Sex { get; set; }

        public int Season { get; set; }

        public bool IsNew { get; set; }

        public string Color { get; set; }
    }
}
