using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;
using api.Queries;

namespace api.Interfaces
{
    public interface IStockRepository
    {
        public Task<List<Stock>> GetAllAsync(StockQuery query);
        public Task<Stock?> GetByIdAsync(int id);
        public Task<Stock> CreateAsync(Stock stockModel);
        public Task<Stock?> DeleteAsync(int id);
        public Task<Stock?> UpdateAsync(int id, StockUpdateDto stockDto);
        public Task<bool> IsExistsAsync(int id);
    }
}