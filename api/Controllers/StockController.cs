namespace api.Controllers;

using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/stock")]
public class StockController(IStockRepository stockRepository) : ControllerBase
{
    private readonly IStockRepository stockRepository = stockRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var stocks = await stockRepository.GetAllAsync();
        var stockDtos = stocks.Select(x => x.ToStockDto());
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
    {
        var stock = await stockRepository.GetByIdAsync(id);
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
        await this.stockRepository.CreateAsync(stockModel);
        return CreatedAtAction(nameof(GetByIdAsync), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] UpdateStockDto stockDto)
    {
        var stock = await stockRepository.UpdateAsync(id, stockDto);
        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock.ToStockDto());
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync([FromRoute] int id)
    {
        return await stockRepository.DeleteAsync(id) is null ? NotFound() : NoContent();
    }
}
