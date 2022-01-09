using System;
using System.Collections.Generic;
using System.Text;

namespace Ski4U.Data.Models
{
    public class Order : IEntityWithId
    {
        public int Id { get; set; }

        public double Price { get; set; }

        public IList<SkiItem> SkiItems { get; set; } = new List<SkiItem>();

        // public Customer Customer { get; set; }
    }
}
