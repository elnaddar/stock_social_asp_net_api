using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Queries
{
    public class StockQuery
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? Industry { get; set; } = null;
    }
}