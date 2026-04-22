using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Customer;

public class CustomerMessagesResponse
{
    [JsonPropertyName("messages")]
    public IEnumerable<CustomerMessageEntry> Messages { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class CustomerMessageEntry
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("metric")]
    public string Metric { get; set; } = null!;

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("body_url")]
    public string? BodyUrl { get; set; }
}
