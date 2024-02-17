using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ArbitrageBot.Messages;

public class BaseMessage
{
    [JsonProperty("e")]
    public required string Event { get; set; }
    [JsonProperty("E"), JsonConverter(typeof(UnixDateTimeConverter))]
    public DateTime EventTime { get; set; }
}
