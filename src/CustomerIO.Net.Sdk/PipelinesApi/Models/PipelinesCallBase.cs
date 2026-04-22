using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Base fields shared by all Pipelines API calls (identify, track, page, screen, group).
/// When integrating through a library, most of these fields are populated automatically.
/// </summary>
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(IdentifyRequest), "identify")]
[JsonDerivedType(typeof(TrackRequest), "track")]
[JsonDerivedType(typeof(PageRequest), "page")]
[JsonDerivedType(typeof(ScreenRequest), "screen")]
[JsonDerivedType(typeof(GroupRequest), "group")]
public abstract class PipelinesCallBase
{

    /// <summary>
    /// The unique identifier for a person. Required unless <see cref="AnonymousId"/> is set.
    /// </summary>
    [JsonPropertyName("userId")]
    public string? UserId { get; set; }

    /// <summary>
    /// A unique substitute for <see cref="UserId"/> used before a person is identified.
    /// Customer.io source libraries generate this automatically.
    /// </summary>
    [JsonPropertyName("anonymousId")]
    public string? AnonymousId { get; set; }

    /// <summary>
    /// A unique identifier for this individual call. Customer.io sets this when using
    /// a source library; you can provide your own value to deduplicate events.
    /// </summary>
    [JsonPropertyName("messageId")]
    public string? MessageId { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp when a library sent the event to Data Pipelines.
    /// </summary>
    [JsonPropertyName("sentAt")]
    public string? SentAt { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp on the client device when the call was invoked,
    /// or the value you manually passed in a server-side library call.
    /// </summary>
    [JsonPropertyName("originalTimestamp")]
    public string? OriginalTimestamp { get; set; }

    /// <summary>
    /// The ISO 8601 timestamp when the event originally occurred. Useful for
    /// backfilling historical data. If omitted, Customer.io uses the current server time.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public string? Timestamp { get; set; }

    /// <summary>
    /// Context about the source call — device, location, library, page, etc.
    /// </summary>
    [JsonPropertyName("context")]
    public PipelinesContext? Context { get; set; }

    /// <summary>
    /// A dictionary of integration flags. By default all integrations are enabled.
    /// Set <c>"All": false</c> to disable all, then enable specific ones as needed.
    /// </summary>
    [JsonPropertyName("integrations")]
    public Dictionary<string, bool>? Integrations { get; set; }
}
