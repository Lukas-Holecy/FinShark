namespace api.Controllers;

using System.Collections;
using System.Collections.Generic;
using api.Data;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/stock")]
public class StockController(ApplicationDBContext context) : ControllerBase
{
    private readonly ApplicationDBContext context = context;

    [HttpGet]
    public IActionResult GetAll()
    {
        var stocks = context.Stocks.ToList().
            Select(x => x.ToStockDto());
        return Ok(stocks);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var stock = context.Stocks.Find(id)?.ToStockDto();
        if (stock == null)
        {
            return NotFound();
        }

        return Ok(stock);
    }
}
