using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var stocks = _context.Stocks.Select(s => s.ToStockDto());
            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Stocks.Find(id);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStock();
            _context.Stocks.Add(stockModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = stockModel.Id }, stockModel.ToStockDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateStockRequestDto stockDto)
        {
            var stockModel = _context.Stocks.Find(id);
            if (stockModel is null)
            {
                return NotFound();
            }
            stockModel.FromUpdateDto(stockDto);

            _context.SaveChanges();

            return Ok(stockModel.ToStockDto());
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var stockModel = _context.Stocks.Find(id);
            if (stockModel is null)
            {
                return NotFound();
            }
            _context.Stocks.Remove(stockModel);
            _context.SaveChanges();
            return Ok(stockModel.ToStockDto());
        }
    }
}