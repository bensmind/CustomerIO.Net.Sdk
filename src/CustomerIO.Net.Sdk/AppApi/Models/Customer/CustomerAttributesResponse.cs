using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Customer;

public class CustomerAttributesResponse
{
    [JsonPropertyName("customer")]
    public CustomerAttributes Customer { get; set; } = null!;
}

public class CustomerAttributes
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("cio_id")]
    public string? CioId { get; set; }

    [JsonPropertyName("created_at")]
    public long? CreatedAt { get; set; }

    [JsonPropertyName("unsubscribed")]
    public bool? Unsubscribed { get; set; }

    /// <summary>Additional custom attributes on the customer profile.</summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? CustomAttributes { get; set; }
}
