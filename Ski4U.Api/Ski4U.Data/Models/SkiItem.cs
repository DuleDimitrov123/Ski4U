using System.Collections.Generic;

namespace Ski4U.Data.Models
{
    public class SkiItem : IEntityWithId
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public int Season { get; set; }

        public bool IsNew { get; set; }

        public string Color { get; set; }

        public IList<SkiItemAttribute> SkiItemAttributes { get; set; } = new List<SkiItemAttribute>();

        public IList<Comment> Comments { get; set; } = new List<Comment>();

        public IList<Order> Orders { get; set; } = new List<Order>();
    }
}
