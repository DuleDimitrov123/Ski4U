namespace Ski4U.Data.Models
{
    public class SkiItemAttribute : IEntityWithId
    {
        public int Id { get; set; }

        public SkiItem SkiItem { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
