using BinanceWebSocketApi.Abstractions;
using BinanceWebSocketApi.Messages;
using Newtonsoft.Json;
using System;

namespace BinanceWebSocketApi.WebSocket
{
    public class BinanceMessageHandler : IBinanceMessageHandler
    {
        private readonly Dictionary<string, Action<string>> _eventHandlers;

        public event EventHandler<PriceMessage> PriceUpdated;
        public event EventHandler<KlineMessage> KlineUpdated;

        public BinanceMessageHandler()
        {
            _eventHandlers = new Dictionary<string, Action<string>>()
            {
                { "24hrMiniTicker", HandlePriceMessage },
                { "kline", HandleKlineMessage },
            };
        }
        public void DispatchMessage(string message)
        {
            var msg = JsonConvert.DeserializeObject<Message>(message);
            if (msg is not null && msg.EventType is not null && _eventHandlers.TryGetValue(msg.EventType, out var handler))
                handler(message);
        }

        private void HandlePriceMessage(string message)
        {
            var priceMessage = JsonConvert.DeserializeObject<PriceMessage>(message);
            PriceUpdated?.Invoke(this, priceMessage);
        }

        private void HandleKlineMessage(string message)
        {
            var klineMessage = JsonConvert.DeserializeObject<KlineMessage>(message);
            KlineUpdated?.Invoke(this, klineMessage);
        }
    }
}
