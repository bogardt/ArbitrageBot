namespace ArbitrageBot.Subscriptions;

public class MiniTickerSubscription : BinanceSubscriptionBase
{
    public MiniTickerSubscription(string symbol) : base(symbol)
    {
    }

    public override string Channel => "miniTicker";
}
