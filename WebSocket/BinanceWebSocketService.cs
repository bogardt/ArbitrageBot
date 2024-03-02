using System.Net.WebSockets;
using System.Text;
using System.Reactive.Subjects;
using Newtonsoft.Json;
using BinanceWebSocketApi.Messages;
using BinanceWebSocketApi.Abstractions;
using System;

namespace BinanceWebSocketApi.WebSocket
{
    public class BinanceWebSocketService : IBinanceWebSocketService, IDisposable
    {
        private readonly ClientWebSocket _webSocket = new();
        private readonly Subject<string> _messageReceivedSubject = new();

        private readonly IBinanceMessageHandler _binanceMessageHandler;

        public IObservable<string> MessageReceived => _messageReceivedSubject;

        public BinanceWebSocketService(IBinanceMessageHandler binanceMessageHandler)
        {
            _binanceMessageHandler = binanceMessageHandler;
        }

        private async void StartReceiving()
        {
            var buffer = new byte[1024 * 4];
            while (_webSocket.State == WebSocketState.Open)
            {
                var result = await _webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var message = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    _messageReceivedSubject.OnNext(message);

                    _binanceMessageHandler.DispatchMessage(message);
                }
            }
        }

        public async Task ConnectAsync(string uri)
        {
            await _webSocket.ConnectAsync(new Uri(uri), CancellationToken.None);
            StartReceiving();
        }

        public async Task SendAsync(string data)
        {
            var buffer = Encoding.UTF8.GetBytes(data);
            await _webSocket.SendAsync(new ArraySegment<byte>(buffer), WebSocketMessageType.Text, true, CancellationToken.None);
        }

        public async Task CloseAsync()
        {
            await _webSocket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
        }

        public void Dispose()
        {
            _webSocket?.Dispose();
            _messageReceivedSubject?.Dispose();
        }
    }
}