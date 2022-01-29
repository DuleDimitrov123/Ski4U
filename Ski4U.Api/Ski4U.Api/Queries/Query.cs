using HotChocolate;
using HotChocolate.Data;
using Ski4U.Data.Models;
using Ski4U.DataLoader.DataLoaders;
using Ski4U.Repository.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Ski4U.Api.Models.FavoriteModels;

namespace Ski4U.Api.Queries
{
    public class Query
    {

        #region SkiItem

        [UseSorting]
        [UseFiltering]
        public async Task<IList<SkiItem>> GetSkiItems([Service] ISkiItemRepository skiItemRepository)
        {
            //return await skiItemRepository.GetAllWithIncludes(item => item.SkiItemAttributes);
            return await skiItemRepository.GetAll();
        }

        [UseSorting]
        [UseFiltering]
        public async Task<SkiItem> GetSkiItem(int id, SkiItemBatchDataLoader dataLoader)
        {
            return await dataLoader.LoadAsync(id);
        }

        #endregion

        #region SkiItemAttribute
        [UseSorting]
        [UseFiltering]
        public async Task<IList<SkiItemAttribute>> GetSkiItemAttributes([Service] ISkiItemAttributeRepository skiItemAttributeRepository)
        {
            //return await skiItemAttributeRepository.GetAllWithIncludes(attribute => attribute.SkiItem);
            return await skiItemAttributeRepository.GetAll();
        }
        #endregion

        #region Customer

        [UseSorting]
        [UseFiltering]
        public async Task<IList<Customer>> GetCustomers([Service] ICustomerRepository customerRepository)
        {
            var customers = await customerRepository.GetAll();
            return customers;
        }

        [UseSorting]
        [UseFiltering]
        public async Task<Customer> GetCustomer(int id, CustomerBatchDataLoader dataLoader)
        {
            return await dataLoader.LoadAsync(id);
        }

        #endregion

        #region Comment

        [UseSorting]
        [UseFiltering]
        public async Task<IList<Comment>> GetComments([Service] ICommentRepository commentRepository)
        {
            return await commentRepository.GetAll();
        }

        #endregion

        #region Order

        [UseSorting]
        [UseFiltering]
        public async Task<IList<Order>> GetOrders([Service] IOrderRepository orderRepository)
        {
            return await orderRepository.GetAll();
        }

        [UseSorting]
        [UseFiltering]
        public async Task<Order> GetOrder(int id, OrderBatchDataLoader dataLoader)
        {
            return await dataLoader.LoadAsync(id);
        }

        [UseSorting]
        [UseFiltering]
        public async Task<List<Order>> GetMutlipleIdOrders(List<int> id, OrderBatchDataLoader dataLoader)
        {
            return (List<Order>)await dataLoader.LoadAsync(id);
        }

        #endregion

        #region Favorite

        [UseSorting]
        [UseFiltering]
        public async Task<IList<Favorite>> GetFavorites([Service] IFavoriteRepository favoriteRepository)
        {
            return await favoriteRepository.GetAll();
        }

        [UseSorting]
        [UseFiltering]
        public async Task<Favorite> GetFavorite(GetFavoriteRequest request,
            FavoritesBatchDataLoader dataLoader)
        {
            return await dataLoader.LoadAsync(request.FavoriteId);
        }

        #endregion
    }
}
