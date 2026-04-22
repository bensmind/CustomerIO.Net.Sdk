using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Transactional;

/// <summary>
/// Identifies a person for a transactional message. Only one property should be set.
/// </summary>
public class TransactionalIdentifiers
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("cio_id")]
    public string? CioId { get; set; }
}
