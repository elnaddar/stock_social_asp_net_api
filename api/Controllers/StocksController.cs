using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StocksController : ControllerBase
    {
        private readonly IStockRepository _repo;
        public StocksController(IStockRepository repo)
        {
            _repo = repo;
        }

        [HttpGet(Name = "Stocks.Index")]
        public async Task<IActionResult> GetAll([FromQuery] StockQuery query)
        {
            var stocks = await _repo.GetAllAsync(query);
            if (stocks.IsNullOrEmpty())
            {
                return BadRequest("Empty response.");
            }
            var stocksDto = stocks.Select(s => s.ToStockDto());
            return Ok(stocksDto);
        }

        [HttpGet("{id:int}", Name = "Stocks.Show")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var stock = await _repo.GetByIdAsync(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost(Name = "Stocks.Store")]
        public async Task<IActionResult> CreateAsync([FromBody] StockCreateDto stockDto)
        {
            var stockModel = stockDto.ToStock();
            await _repo.CreateAsync(stockModel);
            return CreatedAtRoute("Stocks.Show", new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut("{id:int}", Name = "Stocks.Update")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] StockUpdateDto stockDto)
        {
            var stockModel = await _repo.UpdateAsync(id, stockDto);
            if (stockModel is null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{id:int}", Name = "Stocks.Destroy")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            var stockModel = await _repo.DeleteAsync(id);
            if (stockModel is null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStockDto());
        }
    }
}