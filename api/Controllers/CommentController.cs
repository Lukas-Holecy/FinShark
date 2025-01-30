namespace api.Controllers;

using api.Mappers;
using Microsoft.AspNetCore.Mvc;

[Route("api/comment")]
[ApiController]
public class CommentController(ICommentRepository commentRepository) : ControllerBase
{
    private readonly ICommentRepository commentRepository = commentRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var comments = await commentRepository.GetCommentsAsync();
        var commentsDtos = comments.Select(x => x.ToCommentDto());
        return Ok(commentsDtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var comment = await commentRepository.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }

        return Ok(comment.ToCommentDto());
    }
}
