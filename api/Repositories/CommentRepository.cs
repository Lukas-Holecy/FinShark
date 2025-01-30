namespace api.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Comment;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

public class CommentRepository(ApplicationDBContext context) : ICommentRepository
{
    private readonly ApplicationDBContext context = context;

    public Task<Comment> CreateCommentAsync(Comment comment)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> DeleteCommentAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Comment?> GetCommentByIdAsync(int id)
    {
        return await his.context.Comments.FindAsync(id);
    }

    public async Task<IEnumerable<Comment>> GetCommentsAsync()
    {
        return await this.context.Comments.ToListAsync();
    }

    public Task<IEnumerable<Comment>> GetCommentsByPostIdAsync(int postId)
    {
        throw new NotImplementedException();
    }

    public Task<Comment?> UpdateCommentAsync(int Id, UpdateCommentDto commentDto)
    {
        throw new NotImplementedException();
    }
}
