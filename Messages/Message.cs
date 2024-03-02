using BinanceWebSocketApi.Abstractions;
using Newtonsoft.Json;

namespace BinanceWebSocketApi.Messages;

public class Message : EventArgs, IBaseMessage
{
    [JsonProperty("e")]
    public string EventType { get; set; }
    [JsonProperty("E")]
    public long EventTime { get; set; }
}
