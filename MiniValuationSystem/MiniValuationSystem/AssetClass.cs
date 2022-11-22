namespace MiniValuationSystem
{
    public class Trade
    {
        public int TradeId { get; set; }
        public string? Counterparty { get; set; }
        public double Quantity { get; set; }
        public string? TradeType { get; set; }
    }
    public class FXForward : Trade 
    {
        public string? CurrencyPair { get; set; }
        public double Strike { get; set; }
        public DateOnly ExpiryDate { get; set; }
    }

    public class FXOption : Trade
    {
        public string? CurrencyPair { get; set; }
        public double Strike { get; set; }
        public string? OptionType { get; set; }
        public DateOnly ExpiryDate { get; set; }
    }

    public class Rates : Trade
    {
        public string? Underlying { get; set; }
        public double FixedRate { get; set; }
    }
    public class Equities : Trade
    {
        public string? Ticker { get; set; }
    }
}
