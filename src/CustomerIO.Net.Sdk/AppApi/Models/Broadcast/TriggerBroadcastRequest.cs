using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Broadcast;

public class TriggerBroadcastRequest
{
    /// <summary>
    /// Liquid data passed to the broadcast template via {{trigger.&lt;key&gt;}}.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <summary>
    /// Optional: filters the recipients to a specific segment.
    /// </summary>
    [JsonPropertyName("recipients")]
    public BroadcastRecipients? Recipients { get; set; }

    /// <summary>
    /// Optional: per-recipient attribute overrides keyed by email or id.
    /// </summary>
    [JsonPropertyName("per_user_data")]
    public IEnumerable<BroadcastPerUserData>? PerUserData { get; set; }

    /// <summary>
    /// Optional: a deduplicate id to prevent double-triggering the same broadcast.
    /// </summary>
    [JsonPropertyName("id_ignore_missing")]
    public bool? IdIgnoreMissing { get; set; }
}

public class BroadcastRecipients
{
    /// <summary>
    /// Restrict the broadcast to a specific segment by ID.
    /// </summary>
    [JsonPropertyName("segment")]
    public BroadcastSegmentFilter? Segment { get; set; }
}

public class BroadcastSegmentFilter
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class BroadcastPerUserData
{
    /// <summary>
    /// The person's identifier (email or id).
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Liquid data specific to this person, accessible via {{trigger.&lt;key&gt;}}.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }
}
