using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        {
            return new()
            {
                Id = comment.Id,
                Title = comment.Title,
                Content = comment.Content,
                CreatedOn = comment.CreatedOn,
                StockId = comment.StockId,
            };
        }
        public static Comment ToComment(this CommentCreateDto commentDto, int stockId)
        {
            return new()
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId,
            };
        }

        public static void FromUpdateDto(this Comment comment, CommentUpdateDto updateDto)
        {
            comment.Title = updateDto.Title;
            comment.Content = updateDto.Content;
        }
    }
}