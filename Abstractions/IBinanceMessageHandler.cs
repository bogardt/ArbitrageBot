using BinanceWebSocketApi.Messages;

namespace BinanceWebSocketApi.Abstractions
{
    public interface IBinanceMessageHandler
    {
        event EventHandler<PriceMessage> PriceUpdated;
        event EventHandler<KlineMessage> KlineUpdated;
        void DispatchMessage(string message);
    }
}