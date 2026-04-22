using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Newsletter;

public class SendNewsletterRequest
{
    /// <summary>
    /// Liquid data referenced in the newsletter via {{trigger.&lt;key&gt;}}.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <summary>
    /// Optional: restricts the send to a specific segment.
    /// </summary>
    [JsonPropertyName("recipients")]
    public NewsletterRecipients? Recipients { get; set; }

    /// <summary>
    /// Optional per-recipient data overrides.
    /// </summary>
    [JsonPropertyName("per_user_data")]
    public IEnumerable<NewsletterPerUserData>? PerUserData { get; set; }
}

public class ScheduleNewsletterRequest
{
    /// <summary>
    /// Unix timestamp for when to send the newsletter.
    /// </summary>
    [JsonPropertyName("scheduled_at")]
    public long ScheduledAt { get; set; }

    /// <summary>
    /// Liquid data referenced in the newsletter via {{trigger.&lt;key&gt;}}.
    /// </summary>
    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }

    /// <summary>
    /// Optional: restricts the scheduled send to a specific segment.
    /// </summary>
    [JsonPropertyName("recipients")]
    public NewsletterRecipients? Recipients { get; set; }
}

public class NewsletterRecipients
{
    [JsonPropertyName("segment")]
    public NewsletterSegmentFilter? Segment { get; set; }
}

public class NewsletterSegmentFilter
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class NewsletterPerUserData
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("data")]
    public Dictionary<string, object?>? Data { get; set; }
}
