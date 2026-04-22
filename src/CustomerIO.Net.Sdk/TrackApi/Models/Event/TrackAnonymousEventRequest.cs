using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Event;

public class TrackAnonymousEventRequest
{
    /// <summary>
    /// The name of the event. This is how you reference the event in campaigns or segments.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// An identifier for an anonymous person (e.g. a cookie value). If event merging is enabled
    /// and a person is later identified with the same anonymous_id, this event is associated with them.
    /// </summary>
    [JsonPropertyName("anonymous_id")]
    public string? AnonymousId { get; set; }

    /// <summary>
    /// A ULID used to deduplicate events. If an event with the same value was already received,
    /// the duplicate is ignored.
    /// </summary>
    [JsonPropertyName("id")]
    public string? DedupeId { get; set; }

    /// <summary>
    /// The event type. Use <see cref="TrackEventType"/> constants.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Unix timestamp when the event occurred. If omitted, the request time is used.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>
    /// Additional data to reference in messages via liquid or use as attributes.
    /// Values should be strings, numbers, or booleans.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }
}
