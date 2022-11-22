using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniValuationSystem
{
    public class PVCalculation
    {
        public double CalculatePV(double Quantity, double Price)
        {
            return Quantity * Price;
        }
        public double CalculatePV(double Quantity, double Price, string OptionType, double Strike)
        {
            if (OptionType == "Put")
                return Quantity * Math.Max(Price, Strike);

            else if (OptionType == "Call")
                return Quantity * Math.Min(Price, Strike);

            else
                return 0;
        }

        public double CalculatePV(double Quantity, double Price, double FixedRate)
        {
            return Quantity * FixedRate / Price;
        }
    }
}
