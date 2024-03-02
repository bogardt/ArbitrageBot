using Newtonsoft.Json;

namespace BinanceWebSocketApi.Messages;

public class KlineMessage : Message
{
    [JsonProperty("s")]
    public string? Symbol { get; set; }

    [JsonProperty("k")]
    public KlineDetails? Kline { get; set; }
}

public class KlineDetails
{
    [JsonProperty("t")]
    public long? StartTime { get; set; }

    [JsonProperty("T")]
    public long? CloseTime { get; set; }

    [JsonProperty("s")]
    public string? Symbol { get; set; }

    [JsonProperty("i")]
    public string? Interval { get; set; }

    [JsonProperty("f")]
    public int? FirstTradeId { get; set; }

    [JsonProperty("L")]
    public int? LastTradeId { get; set; }

    [JsonProperty("o")]
    public string? OpenPrice { get; set; }

    [JsonProperty("c")]
    public string? ClosePrice { get; set; }

    [JsonProperty("h")]
    public string? HighPrice { get; set; }

    [JsonProperty("l")]
    public string? LowPrice { get; set; }

    [JsonProperty("v")]
    public string? BaseAssetVolume { get; set; }

    [JsonProperty("n")]
    public int? NumberOfTrades { get; set; }

    [JsonProperty("x")]
    public bool? IsKlineClosed { get; set; }

    [JsonProperty("q")]
    public string? QuoteAssetVolume { get; set; }

    [JsonProperty("V")]
    public string? TakerBuyBaseAssetVolume { get; set; }

    [JsonProperty("Q")]
    public string? TakerBuyQuoteAssetVolume { get; set; }

    [JsonProperty("B")]
    public string? Ignore { get; set; }
}