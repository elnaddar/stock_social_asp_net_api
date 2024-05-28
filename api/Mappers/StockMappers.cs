using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.Mappers
{
    public static class StockMappers
    {
        public static StockDto ToStockDto(this Stock stockModel)
        {
            return new()
            {
                Id = stockModel.Id,
                Symbol = stockModel.Symbol,
                CompanyName = stockModel.CompanyName,
                Purchase = stockModel.Purchase,
                LastDiv = stockModel.LastDiv,
                Industry = stockModel.Industry,
                MarketCap = stockModel.MarketCap,
            };
        }

        public static Stock ToStock(this CreateStockRequestDto createDto)
        {
            return new()
            {
                Symbol = createDto.Symbol,
                CompanyName = createDto.CompanyName,
                Purchase = createDto.Purchase,
                LastDiv = createDto.LastDiv,
                Industry = createDto.Industry,
                MarketCap = createDto.MarketCap,
            };
        }
    }
}