using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniValuationSystem
{
    public class Result
    {
        public int TradeId { get; set; }
        public double PV { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
