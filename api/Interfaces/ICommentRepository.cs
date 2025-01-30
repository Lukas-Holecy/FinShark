namespace api;

using api.Dtos.Comment;
using api.Models;

public interface ICommentRepository
{
    Task<IEnumerable<Comment>> GetCommentsAsync();
    Task<Comment?> GetCommentByIdAsync(int id);
    Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId);
    Task<Comment> CreateCommentAsync(int stockId, Comment comment);
    Task<Comment?> UpdateCommentAsync(int Id, UpdateCommentDto commentDto);
    Task<Comment?> DeleteCommentAsync(int id);
}
