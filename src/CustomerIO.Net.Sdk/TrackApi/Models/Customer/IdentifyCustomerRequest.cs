using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Customer;

public class IdentifyCustomerRequest
{
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; set; }

    /// <summary>
    /// Unix timestamp used to control the order of attribute updates when multiple requests
    /// are sent in rapid succession.
    /// </summary>
    [JsonPropertyName("_timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>
    /// If true, the request will only update an existing person and will not create a new one
    /// if the identifier is not found.
    /// </summary>
    [JsonPropertyName("_update")]
    public bool? Update { get; set; }

    /// <summary>
    /// If true, the person is globally unsubscribed from all messages.
    /// </summary>
    [JsonPropertyName("unsubscribed")]
    public bool? Unsubscribed { get; set; }

    [JsonPropertyName("anonymous_id")]
    public string? AnonymousId { get; set; }

    /// <summary>
    /// Custom attributes to set on the person. Values should be strings, integers, or booleans.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? CustomAttributes { get; set; }
}
