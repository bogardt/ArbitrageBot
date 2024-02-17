using ArbitrageBot.Messages;
using ArbitrageBot.Subscriptions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Reactive.Linq;
using Websocket.Client;

namespace ArbitrageBot.WebSocket;

public class BinanceWebSocket : IDisposable
{
    private readonly IDisposable _disposable;
    private readonly IWebsocketClient _webSocketClient;
    private readonly ILogger<BinanceWebSocket> _logger;
    private readonly BinanceResponses _responses = new BinanceResponses();
    public BinanceWebSocket(IWebsocketClient webSocketClient,
        ILogger<BinanceWebSocket> logger)
    {
        // validate input with fluentvalidation

        _disposable = webSocketClient.MessageReceived.Subscribe(HandleMessage);
        _webSocketClient = webSocketClient;
        _logger = logger;
    }

    public void Dispose() => _disposable?.Dispose();

    public Uri PrepareSubscriptions(Uri baseUrl, params BaseSubscription[] subscriptions)
    {
        if (baseUrl is null)
            throw new Exception("baseUrl is null");

        if (subscriptions is null || !subscriptions.Any())
            throw new Exception("Subscription is empty");

        var streams = subscriptions.Select(x => x.StreamName).ToArray();
        var urlPart = string.Join("/", streams);
        var urlPartFull = $"/stream?streams={urlPart}";

        var currentUrl = baseUrl.ToString().Trim();

        if (currentUrl.Contains("stream?"))
        {
            return baseUrl;
        }

        var newUrl = new Uri($"{currentUrl.TrimEnd('/')}{urlPartFull}");
        return newUrl;
    }

    public void SetSubscriptions(params BaseSubscription[] subscriptions)
    {
        var newUrl = PrepareSubscriptions(_webSocketClient.Url, subscriptions);
        _webSocketClient.Url = newUrl;
        if (!_webSocketClient.IsRunning)
        {
            _webSocketClient.Start();
        }
    }

    private void HandleMessage(ResponseMessage message)
    {
        try
        {
            var json = JsonConvert.DeserializeObject<BaseResponse>(message?.Text!);
            if (json != null)
            {
                var value = json.Stream;


                _responses._miniTickerSubject.OnNext(json);

            }

            _logger.LogWarning($"Unhandled response:  '{message?.Text}'");
        }
        catch (Exception e)
        {
            _logger.LogError(e, $"Exception while receiving message '{message.Text}'");
        }
    }
}
