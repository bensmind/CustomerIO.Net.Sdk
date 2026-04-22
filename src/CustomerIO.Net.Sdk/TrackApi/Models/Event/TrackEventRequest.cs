using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Event;

public class TrackEventRequest
{
    /// <summary>
    /// The name of the event. This is how you reference the event in campaigns or segments.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// A ULID used to deduplicate events. If an event with the same value was already received,
    /// the duplicate is ignored.
    /// </summary>
    [JsonPropertyName("id")]
    public string? DedupeId { get; set; }

    /// <summary>
    /// The event type. Defaults to "event". Use <see cref="TrackEventType"/> constants.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    /// <summary>
    /// Unix timestamp when the event occurred. If omitted, the request time is used.
    /// Events within the past 72 hours can trigger campaigns.
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

public static class TrackEventType
{
    public const string Event = "event";
    public const string Page = "page";
    public const string Screen = "screen";
}
