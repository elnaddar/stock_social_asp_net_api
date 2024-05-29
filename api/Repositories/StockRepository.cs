using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class StockRepository(ApplicationDbContext context) : IStockRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stocks.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stockModel = await GetByIdAsync(id);
            if (stockModel is null)
            {
                return null;
            }
            _context.Stocks.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<List<Stock>> GetAllAsync()
        => await _context.Stocks.Include(c => c.Comments).ToListAsync();

        public async Task<Stock?> GetByIdAsync(int id)
        => await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(s => s.Id == id);

        public async Task<bool> IsExistsAsync(int id) => await _context.Stocks.AnyAsync(s => s.Id == id);

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var stockModel = await GetByIdAsync(id);
            if (stockModel is null)
            {
                return null;
            }

            stockModel.FromUpdateDto(stockDto);
            await _context.SaveChangesAsync();
            return stockModel;
        }
    }
}