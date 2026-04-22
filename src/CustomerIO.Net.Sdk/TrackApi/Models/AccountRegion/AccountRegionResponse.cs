using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.AccountRegion;

public class AccountRegionResponse
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
    [JsonPropertyName("region")]
    public string Region { get; set; } = null!;
    [JsonPropertyName("environment_id")]
    public string EnvironmentId { get; set; } = null!;
}