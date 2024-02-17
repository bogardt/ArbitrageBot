using ArbitrageBot.Abstractions;

namespace ArbitrageBot.Exchanges;

public class BinanceExchange : AbstractExchange
{
    private readonly IWebSocket _webSocket;

    public BinanceExchange(IWebSocket webSocket) : base(webSocket)
    {
        _webSocket = webSocket;
    }
}
