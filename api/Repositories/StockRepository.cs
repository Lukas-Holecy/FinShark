namespace api.Repositories;

using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

public class StockRepository(ApplicationDBContext context) : IStockRepository
{
    private readonly ApplicationDBContext context = context;

    public async Task<Stock> CreateAsync(Stock stock)
    {
        await this.context.Stocks.AddAsync(stock);
        await context.SaveChangesAsync();
        return stock;
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stock = await this.GetByIdAsync(id);
        if (stock == null)
        {
            return null;
        }

        context.Stocks.Remove(stock);
        await context.SaveChangesAsync();
        return stock;
    }

    public async Task<IEnumerable<Stock>> GetAllAsync()
    {
        return await this.context.Stocks.Include(c => c.Comments).ToListAsync();
    }

    public async Task<Stock?> GetByIdAsync(int id)
    {
        return await this.context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockDto stockDto)
    {
        var stock = await this.GetByIdAsync(id);
        if (stock == null)
        {
            return null;
        }

        stock.Symbol = stockDto.Symbol;
        stock.CompanyName = stockDto.CompanyName;
        stock.Purchase = stockDto.Purchase;
        stock.LastDiv = stockDto.LastDiv;
        stock.Industry = stockDto.Industry;
        stock.MarketCap = stockDto.MarketCap;

        await context.SaveChangesAsync();
        return stock;
    }

    public async Task<bool> StockExistsAsync(int id)
    {
        return await this.context.Stocks.AnyAsync(e => e.Id == id);
    }
}
