using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Customer;

/// <summary>
/// Identifies a person by one of their identifiers. Only one property should be set.
/// </summary>
public class CustomerIdentifier
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("cio_id")]
    public string? CioId { get; set; }
}
