using HotChocolate;
using Ski4U.Data.Models;
using Ski4U.Repository.Contracts;
using System.Threading.Tasks;
using static Ski4U.Api.Models.SkiItemModels;

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

            return await skiItemRepository.Add(skiItem);
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

        #region Comment

        public async Task<Comment> AddComment(AddCommentRequest request,
            [Service] ICommentRepository commentRepository,
            [Service] ISkiItemRepository skiItemRepository)
        {

            SkiItem skiItem = await skiItemRepository.GetOne(request.SkiItemId);

            var comment = new Comment
            {
                CommentText = request.CommentText,
                SkiItemId = request.SkiItemId,
                SkiItem = skiItem
            };

            skiItem.Comments.Add(comment);

            await skiItemRepository.Update(skiItem);
            return await commentRepository.Add(comment);
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


        #endregion
    }
}
