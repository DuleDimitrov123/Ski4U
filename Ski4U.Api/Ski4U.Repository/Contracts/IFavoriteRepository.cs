using Ski4U.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface IFavoriteRepository : IRepository<Favorite>
    {
        Task<IList<Favorite>> GetFavoritesByIds(IList<int> favoriteIds);

        Task<IList<Favorite>> GetFavoritesByCustomerId(int customerId);

        Task<IList<Favorite>> GetFavoritesByCustomerIds(IList<int> customerIds);

        Task<IList<Favorite>> GetFavoritesBySkiItemsIds(IList<int> skiItemIds);
    }
}
