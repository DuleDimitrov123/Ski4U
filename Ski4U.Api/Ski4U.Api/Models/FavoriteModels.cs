namespace Ski4U.Api.Models
{
    public class FavoriteModels
    {
        public record GetFavoriteRequest(int FavoriteId);

        public record AddFavoriteRequest(int CustomerId, int SkiItemId);

        public record DeleteFavoriteRequest(int FavoriteId);
    }
}
