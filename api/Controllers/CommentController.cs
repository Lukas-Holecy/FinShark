namespace api.Controllers;

using api.Dtos.Comment;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

[Route("api/comment")]
[ApiController]
public class CommentController(ICommentRepository commentRepository, IStockRepository stockRepository) : ControllerBase
{
    private readonly ICommentRepository commentRepository = commentRepository;

    private readonly IStockRepository stockRepository = stockRepository;

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

    [HttpPost("{stockId}")]
    public async Task<IActionResult> CreateAsync([FromRoute] int stockId, [FromBody] CreateCommentDto commentDto)
    {
        if (!await this.stockRepository.StockExistsAsync(stockId))
        {
            return BadRequest("Stock does not exist");
        }

        var commentModel = commentDto.ToCommentFromCreateDto(stockId);
        await this.commentRepository.CreateCommentAsync(stockId, commentModel);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = commentModel.Id }, commentModel.ToCommentDto());
    }

}
