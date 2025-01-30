namespace api.Interfaces;

using api.Dtos.Stock;
using api.Models;

public interface IStockRepository
{
    Task<IEnumerable<Stock>> GetAllAsync();

    Task<Stock?> GetByIdAsync(int id);

    Task<Stock> CreateAsync(Stock stock);

    Task<Stock?> UpdateAsync(int id, UpdateStockDto stock);

    Task<Stock?> DeleteAsync(int id);

    Task<bool> StockExistsAsync(int id);
}
