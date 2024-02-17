using ArbitrageBot.Abstractions;

namespace ArbitrageBot.Exchanges;

public abstract class AbstractExchange
{
    private readonly IWebSocket _webSocket;

    protected AbstractExchange(IWebSocket webSocket)
    {
        _webSocket = webSocket;
    }
}
