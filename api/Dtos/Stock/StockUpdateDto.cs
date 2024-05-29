using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class StockUpdateDto
    {
        [Required]
        [MaxLength(10)]
        public string Symbol { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string CompanyName { get; set; } = string.Empty;
        [Required]
        [Range(0, 1_000_000_000_000_000)]
        [DeniedValues([0])]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001, 100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(30)]
        public string Industry { get; set; } = string.Empty;
        [Required]
        [Range(1, 5_000_000_000_000_000)]
        public long MarketCap { get; set; }
    }
}