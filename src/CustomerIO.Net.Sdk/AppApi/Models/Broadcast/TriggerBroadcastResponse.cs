using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Broadcast;

public class TriggerBroadcastResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}
