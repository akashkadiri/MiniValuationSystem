namespace MiniValuationSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var FxForward = new ReadFxForwardCsv();
            var FXOption = new ReadFXOptionCsv();
            var Rates = new ReadRatesCsv();
            var Equities = new ReadEquitiesCsv();
            var Market = new ReadMarketCsv();
            var ResultServices = new WriteToCsv();
            var Calculations = new PVCalculation();
            List<Result> resultData = new List<Result>();

            //Here We are calling function to read CSV file
            var FXForwardData = FxForward.ReadCsv(@".\Data\FXForward.csv");
            var FXOptionData = FXOption.ReadCsv(@".\Data\FXOption.csv");
            var RatesData = Rates.ReadCsv(@".\Data\IRSwap.csv");
            var EquitiesData = Equities.ReadCsv(@".\Data\Stock.csv");
            var MarketData = Market.ReadCsv(@".\Data\MarketData.csv") ;

            foreach (var i in MarketData)
            {
                // Finding relevant data based on Market Data Key
                var e = EquitiesData.Find(x => x.Ticker == i.Key);
                var r = RatesData.Find(x => x.Underlying == i.Key);
                var f = FXForwardData.Find(x => x.CurrencyPair == i.Key);
                var o = FXOptionData.Find(x => x.CurrencyPair == i.Key);
                
                Result Valuation = new Result();

                if (e is not null)
                {
                    var PV = Calculations.CalculatePV(e.Quantity, i.Price);
                    Valuation.TradeId = e.TradeId;
                    Valuation.PV = PV;
                    resultData.Add(Valuation);
                }
                if (r is not null)
                {
                    var PV = Calculations.CalculatePV(r.Quantity, i.Price, r.FixedRate);
                    Valuation.TradeId = r.TradeId;
                    Valuation.PV = PV;
                    resultData.Add(Valuation);
                }
                if (f is not null)
                {
                    var PV = Calculations.CalculatePV(f.Quantity, i.Price);
                    Valuation.TradeId = f.TradeId;
                    Valuation.PV = PV;
                    resultData.Add(Valuation);
                }
                if (o is not null)
                {
                    var PV = Calculations.CalculatePV(o.Quantity, i.Price, o.OptionType!, o.Strike);
                    Valuation.TradeId = o.TradeId;
                    Valuation.PV = PV;
                    resultData.Add(Valuation);
                }
            }

            // Write Results to CSV
            ResultServices.WriteCsv(@".\Data\Results.csv", resultData);
        }
    }
}