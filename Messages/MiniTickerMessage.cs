using Newtonsoft.Json;

namespace ArbitrageBot.Messages;

public class MiniTickerMessage : BaseMessage
{
    [JsonProperty("s")]
    public string? Symbol { get; set; }
    [JsonProperty("c")]
    public double ClosePrice { get; set; }
    [JsonProperty("o")]
    public double OpenPrice { get; set; }
    [JsonProperty("h")]
    public double HighPrice { get; set; }
    [JsonProperty("l")]
    public double LowPrice { get; set; }
    [JsonProperty("v")]
    public double BaseAssetVolume { get; set; }
    [JsonProperty("q")]
    public double QuoteAssetVolume { get; set; }
}
