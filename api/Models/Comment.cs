namespace api.Models;

public class Comment
{
    public int Id { get; set; }

    /// <summary>
    /// Id of a stock that has this comment attached.
    /// This is called navigation property.
    /// </summary>
    public int? StockId { get; set; }

    public Stock? Stock { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; }

}
