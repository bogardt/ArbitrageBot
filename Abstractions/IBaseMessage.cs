using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace BinanceWebSocketApi.Abstractions;

public interface IBaseMessage
{
    [JsonProperty("e")]
    public string EventType { get; set; }
    [JsonProperty("E")]
    public long EventTime { get; set; }
}
