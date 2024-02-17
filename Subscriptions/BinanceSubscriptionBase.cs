namespace ArbitrageBot.Subscriptions;

public abstract class BinanceSubscriptionBase : BaseSubscription
{

    protected BinanceSubscriptionBase(string symbol)
    {
        Symbol = (symbol ?? string.Empty).ToLower();
    }

    protected BinanceSubscriptionBase()
    {

    }

    public string Symbol { get; }

    public abstract string Channel { get; }

    public override string StreamName => $"{Symbol}@{Channel}";

}
