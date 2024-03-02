using BinanceWebSocketApi.Messages;

namespace BinanceWebSocketApi.Abstractions
{
    public interface IBinanceWebSocketService
    {
        IObservable<string> MessageReceived { get; }
        Task ConnectAsync(string uri);
        Task SendAsync(string message);
        Task CloseAsync();
    }
}