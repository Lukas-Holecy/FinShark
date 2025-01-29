namespace api.Models;

using System.ComponentModel.DataAnnotations.Schema;

public class Stock
{
    public int Id { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Purchase { get; set; }

    /// <summary>
    /// Gets or sets the last dividend. This name is set to match the front ent.
    /// </summary>
    [Column(TypeName = "decimal(18, 2)")]
    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = string.Empty;

    public long MarketCap { get; set; }

    public List<Comment> Comments { get; set; } = [];
}
