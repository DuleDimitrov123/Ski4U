using Ski4U.Data;

namespace Ski4U.Api.Models
{
    public class SkiBootModels
    {
        public record AddSkiBootRequest(double Price, Sex Sex, int Season, bool IsNew, string Color, int SkiBootSize, int SkiBootFlex);
    }
}
