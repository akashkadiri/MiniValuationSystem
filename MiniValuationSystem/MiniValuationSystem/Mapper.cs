using CsvHelper.Configuration;

namespace MiniValuationSystem
{
    public sealed class FXForwardMap : ClassMap<FXForward>
    {
        public FXForwardMap()
        {
            Map(p => p.CurrencyPair).Index(0);
            Map(p => p.Strike).Index(1);
            Map(p => p.ExpiryDate).Index(2);
            Map(p => p.TradeId).Index(3);
            Map(p => p.Counterparty).Index(4);
            Map(p => p.Quantity).Index(5);
            Map(p => p.TradeType).Index(6);
        }
    }

    public sealed class FXOptionMap : ClassMap<FXOption>
    {
        public FXOptionMap()
        {
            Map(p => p.CurrencyPair).Index(0);
            Map(p => p.Strike).Index(1);
            Map(p => p.OptionType).Index(2);
            Map(p => p.ExpiryDate).Index(3);
            Map(p => p.TradeId).Index(4);
            Map(p => p.Counterparty).Index(5);
            Map(p => p.Quantity).Index(6);
            Map(p => p.TradeType).Index(7);
        }
    }
    public sealed class RatesMap : ClassMap<Rates>
    {
        public RatesMap()
        {
            Map(p => p.Underlying).Index(0);
            Map(p => p.FixedRate).Index(1);
            Map(p => p.TradeId).Index(2);
            Map(p => p.Counterparty).Index(3);
            Map(p => p.Quantity).Index(4);
            Map(p => p.TradeType).Index(5);
        }
    }
    public sealed class EquitiesMap : ClassMap<Equities>
    {
        public EquitiesMap()
        {
            Map(p => p.Ticker).Index(0);
            Map(p => p.TradeId).Index(1);
            Map(p => p.Counterparty).Index(2);
            Map(p => p.Quantity).Index(3);
            Map(p => p.TradeType).Index(4);
        }
    }
    public sealed class MarketMap : ClassMap<Market>
    {
        public MarketMap()
        {
            Map(p => p.Key).Index(0);
            Map(p => p.Price).Index(1);
        }
    }
    public sealed class ResultMap : ClassMap<Result>
    {
        public ResultMap()
        {
            Map(p => p.TradeId).Index(0);
            Map(p => p.PV).Index(1);
            Map(p => p.ErrorMessage).Index(2);
        }
    }
}
