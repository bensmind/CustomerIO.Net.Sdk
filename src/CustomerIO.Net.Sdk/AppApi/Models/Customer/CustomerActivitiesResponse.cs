using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Customer;

public class CustomerActivitiesResponse
{
    [JsonPropertyName("activities")]
    public IEnumerable<CustomerActivityEntry> Activities { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class CustomerActivityEntry
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("timestamp")]
    public long Timestamp { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }
}
