namespace api.Dtos.Comment;

public class UpdateCommentDto
{
    public int StockId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;
}
