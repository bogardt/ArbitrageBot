using BinanceWebSocketApi.Abstractions;
using Newtonsoft.Json;

namespace BinanceWebSocketApi.Messages;

public class PriceMessage : Message
{
    [JsonProperty("s")]
    public string? Symbol { get; set; }

    [JsonProperty("c")]
    public string? ClosePrice { get; set; }

    [JsonProperty("o")]
    public string? OpenPrice { get; set; }

    [JsonProperty("h")]
    public string? HighPrice { get; set; }

    [JsonProperty("l")]
    public string? LowPrice { get; set; }

    [JsonProperty("v")]
    public string? TotalTradedBaseAssetVolume { get; set; }

    [JsonProperty("q")]
    public string? TotalTradedQuoteAssetVolume { get; set; }
}
