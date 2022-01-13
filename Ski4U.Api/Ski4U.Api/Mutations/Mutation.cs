using HotChocolate;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Ski4U.Api.Models.CustomerModels;
using static Ski4U.Api.Models.CommentModels;
using static Ski4U.Api.Models.OrderModels;
using static Ski4U.Api.Models.SkiItemModels;
using static Ski4U.Api.Models.FavoriteModels;

namespace Ski4U.Api.Mutations
{
    public class Mutation
    {
        #region SkiItem
        public async Task<SkiItem> AddSkiItem(AddSkiItemRequest request, [Service] ISkiItemRepository skiItemRepository)
        {
            var skiItem = new SkiItem
            {
                Price = request.Price,
                Sex = request.Sex,
                Name = request.Name,
                Season = request.Season,
                IsNew = request.IsNew,
                Color = request.Color
            };

            foreach (var item in request.SkiItemAttributesRequestResponse)
            {
                skiItem.SkiItemAttributes.Add(new SkiItemAttribute
                {
                    SkiItem = skiItem,
                    Name = item.Name,
                    Value = item.Value
                });
            }

            try
            {
                return await skiItemRepository.Add(skiItem);
            }
            catch (Exception e)
            {
                return null;
            }

        }

        public async Task<SkiItem> UpdateSkiItem(UpdateSkiItemRequest request, [Service] ISkiItemRepository skiItemRepository)
        {
            return await skiItemRepository.Update(
                new SkiItem
                {
                    Id = request.Id,
                    Price = request.Price,
                    Sex = request.Sex,
                    Name = request.Name,
                    Season = request.Season,
                    IsNew = request.IsNew,
                    Color = request.Color
                });
        }

        public async Task<SkiItem> DeleteSkiItem(int id, [Service] ISkiItemRepository skiItemRepository, [Service] ISkiItemAttributeRepository skiItemAttributeRepository)
        {
            var skiItemAttributes = await skiItemAttributeRepository.GetAllSkiItemAttributesBySkiItemId(id);

            foreach (var sia in skiItemAttributes)
            {
                await skiItemAttributeRepository.DeleteById(sia.Id);
            }

            return await skiItemRepository.DeleteById(id);
        }
        #endregion

        #region Customers
        public async Task<Customer> AddCustomer(AddCustomerRequest request, [Service] ICustomerRepository customerRepository)
        {
            return await customerRepository.Add(new Customer
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Number = request.Number,
                Address = request.Address
            });
        }

        public async Task<Customer> UpdateCustomer(UpdateCustomerRequest request, [Service] ICustomerRepository customerRepository)
        {
            return await customerRepository.Update(new Customer
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                Number = request.Number,
                Address = request.Address
            });
        }

        public async Task<Customer> DeleteCustomer(int id, [Service] ICustomerRepository customerRepository)
        {
            //add deleting orders, comments and followings for this customer...and maybe something else if we add in the meantime
            return await customerRepository.DeleteById(id);
        }

        #endregion

        #region Comment

        public async Task<Comment> AddComment(AddCommentRequest request,
            [Service] ICommentRepository commentRepository)
        {
            try
            {
                var comment = new Comment
                {
                    CommentText = request.CommentText,
                    SkiItemId = request.SkiItemId,
                    CustomerId = request.CustomerId
                };
                await commentRepository.Add(comment);
                return comment;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Comment> UpdateComment(UpdateCommentRequest request,
            [Service] ICommentRepository commentRepository)
        {
            Comment comment = await commentRepository.GetOne(request.CommentId);
            comment.CommentText = request.CommentText;

            return await commentRepository.Update(comment);
        }

        public async Task<Comment> DeleteComment(int id,
        [Service] ICommentRepository commentRepository)
        {
            return await commentRepository.DeleteById(id);
        }

        #endregion

        #region Order

        public async Task<Order> AddOrder(AddOrderRequest request,
            [Service] ISkiItemRepository skiItemRepository,
            [Service] IOrderRepository orderRepository)
        {
            try
            {
                IList<SkiItem> skiItems = await skiItemRepository.GetSkiItemsByIds(request.Ids);

                double totalPrice = 0;

                foreach (SkiItem skiItem in skiItems)
                {
                    totalPrice += skiItem.Price;
                }

                var order = new Order
                {
                    Price = totalPrice,
                    CustomerId = request.CustomerId
                };

                await orderRepository.Add(order);

                foreach (SkiItem skiItem in skiItems)
                {
                    skiItem.Order = order;

                    await skiItemRepository.Update(skiItem);
                }
                return order;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Order> AddNewSkiItemToOrder(AddNewSkiItemToOrderRequest request,
             [Service] IOrderRepository orderRepository,
             [Service] ISkiItemRepository skiItemRepository)
        {
            SkiItem skiItem = await skiItemRepository.GetOne(request.SkiItemId);
            Order order = await orderRepository.GetOne(request.OrderId);

            order.SkiItems.Add(skiItem);
            order.Price = (int)(order.Price + skiItem.Price);

            return await orderRepository.Update(order);
        }

        public async Task<Order> DeleteOrder(int id,
            [Service] IOrderRepository orderRepository,
            [Service] ISkiItemRepository skiItemRepository)
        {
            var order = orderRepository.GetOneWithIncludes(id, order => order.SkiItems);

            foreach (var skiItem in order.SkiItems)
            {
                skiItem.Order = null;
                await skiItemRepository.Update(skiItem);
            }

            return await orderRepository.DeleteById(id);
        }

        #endregion

        #region Favorite
        public async Task<Favorite> AddFavorite(AddFavoriteRequest request,
            [Service] IFavoriteRepository favoriteRepository)
        {
            var favorite = new Favorite
            {
                CustomerId = request.CustomerId,
                SkiItemId = request.SkiItemId

            };

            return await favoriteRepository.Add(favorite);
        }

        public async Task<Favorite> DeleteFavorite(DeleteFavoriteRequest request,
            [Service] IFavoriteRepository favoriteRepository)
        {
            try
            {
                return await favoriteRepository.DeleteById(request.FavoriteId);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
