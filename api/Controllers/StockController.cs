namespace api.Controllers;

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/stock")]
public class StockController(ApplicationDBContext context) : ControllerBase
{
    private readonly ApplicationDBContext context = context;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var stocks = await context.Stocks.ToListAsync();
        var stockDtos = stocks.Select(x => x.ToStockDto());
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var stock = await context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateStockDto stockDto)
    {
        var stockModel = stockDto.ToStock();
        context.Stocks.Add(stockModel);
        await context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetByIdAsync), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateStockDto stockDto)
    {
        var stock = await context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        stock.Symbol = stockDto.Symbol;
        stock.CompanyName = stockDto.CompanyName;
        stock.Purchase = stockDto.Purchase;
        stock.LastDiv = stockDto.LastDiv;
        stock.Industry = stockDto.Industry;
        stock.MarketCap = stockDto.MarketCap;

        await context.SaveChangesAsync();
        return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        var stock = await context.Stocks.FindAsync(id);
        if (stock == null)
        {
            return NotFound();
        }

        context.Stocks.Remove(stock);
        await context.SaveChangesAsync();
        return NoContent();
    }
}
