namespace api.Mappers;

using api.Dtos.Comment;
using api.Models;

public static class CommentMappers
{
    public static CommentDto ToCommentDto(this Comment comment)
    {
        return new CommentDto
        {
            Id = comment.Id,
            StockId = comment.StockId,
            Title = comment.Title,
            Content = comment.Content,
            CreatedOn = comment.CreatedOn,
        };
    }

    public static Comment ToCommentFromCreateDto(this CreateCommentDto createCommentDto, int stockId)
    {
        return new Comment
        {
            StockId = stockId,
            Title = createCommentDto.Title,
            Content = createCommentDto.Content,
        };
    }
}
