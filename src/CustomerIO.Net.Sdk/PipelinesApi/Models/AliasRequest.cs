using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Request body for the <c>POST /v1/alias</c> endpoint.
/// Merges two profiles, mapping the <see cref="PreviousId"/> to the <see cref="UserId"/>.
/// All future events sent with <see cref="PreviousId"/> will be attributed to
/// the person identified by <see cref="UserId"/>.
/// </summary>
public class AliasRequest
{
    /// <summary>
    /// The previous identifier for the person. Required.
    /// </summary>
    [JsonPropertyName("previousId")]
    public required string PreviousId { get; set; }

    /// <summary>
    /// The new (canonical) identifier for the person. Required.
    /// </summary>
    [JsonPropertyName("userId")]
    public required string UserId { get; set; }

    /// <summary>
    /// A unique identifier for this individual call, used for deduplication.
    /// Customer.io sets this automatically when using a source library.
    /// </summary>
    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp when the library sent this event.
    /// </summary>
    [JsonPropertyName("sentAt")]
    public string? SentAt { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp on the client device when the call was invoked.
    /// </summary>
    [JsonPropertyName("originalTimestamp")]
    public string? OriginalTimestamp { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp when the alias operation took place.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }

    /// <summary>
    /// Context about the source call.
    /// </summary>
    [JsonPropertyName("context")]
    public PipelinesContext? Context { get; set; }

    /// <summary>
    /// A dictionary of integration flags.
    /// </summary>
    [JsonPropertyName("integrations")]
    public Dictionary<string, bool>? Integrations { get; set; }
}
