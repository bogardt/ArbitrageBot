namespace ArbitrageBot.Abstractions;

public interface IWebSocket
{
    Task ConnectAsync();
    Task SubscribeToStreamAsync(string @params);
    Task ReceiveMessagesAsync();
}
