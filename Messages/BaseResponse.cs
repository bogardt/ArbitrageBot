using Newtonsoft.Json;

namespace ArbitrageBot.Messages;

public class BaseResponse
{
    [JsonProperty("stream")]
    public string ?Stream { get; set; }
    [JsonProperty("data")]
    public T ?Data { get; set; }
}
