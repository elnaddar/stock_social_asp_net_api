using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Queries
{
    public class StockQuery
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? Industry { get; set; } = null;
        [AllowedValues("", null, "Symbol", "CompanyName", "Purchase", "LastDiv", "Industry", "MarketCap")]
        public string? SortBy { get; set; } = null;
        public bool IsAscending { get; set; } = true;
        [Range(1, uint.MaxValue)]
        public uint PageNumber { get; set; } = 1;
        [Range(1, byte.MaxValue)]
        public byte PageSize { get; set; } = 20;
    }
}