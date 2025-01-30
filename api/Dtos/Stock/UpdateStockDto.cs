namespace api.Dtos.Stock;

using System.ComponentModel.DataAnnotations.Schema;

public class UpdateStockDto
{
    public string Symbol { get; set; } = string.Empty;

    public string CompanyName { get; set; } = string.Empty;

    public decimal Purchase { get; set; }

    /// <summary>
    /// Gets or sets the last dividend. This name is set to match the front ent.
    /// </summary>
    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = string.Empty;

    public long MarketCap { get; set; }
}
