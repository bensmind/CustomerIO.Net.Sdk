using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Newsletter;

public class NewsletterResponse
{
    [JsonPropertyName("newsletter")]
    public NewsletterDetail Newsletter { get; set; } = null!;
}

public class NewslettersResponse
{
    [JsonPropertyName("newsletters")]
    public IEnumerable<NewsletterDetail> Newsletters { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class NewsletterDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("deduplicate_id")]
    public string? DeduplicateId { get; set; }

    /// <summary>e.g. "email", "push", "sms"</summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("content_ids")]
    public IEnumerable<int>? ContentIds { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("from_id")]
    public int? FromId { get; set; }

    [JsonPropertyName("reply_to_id")]
    public int? ReplyToId { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("subscription_topic_id")]
    public int? SubscriptionTopicId { get; set; }

    [JsonPropertyName("recipient_segment_ids")]
    public IEnumerable<int>? RecipientSegmentIds { get; set; }

    [JsonPropertyName("sent_at")]
    public long? SentAt { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("updated")]
    public long Updated { get; set; }
}

public class NewsletterMetricsResponse
{
    [JsonPropertyName("sent")]
    public long Sent { get; set; }

    [JsonPropertyName("delivered")]
    public long Delivered { get; set; }

    [JsonPropertyName("opened")]
    public long Opened { get; set; }

    [JsonPropertyName("unique_opens")]
    public long UniqueOpens { get; set; }

    [JsonPropertyName("clicks")]
    public long Clicks { get; set; }

    [JsonPropertyName("unique_clicks")]
    public long UniqueClicks { get; set; }

    [JsonPropertyName("bounced")]
    public long Bounced { get; set; }

    [JsonPropertyName("unsubscribed")]
    public long Unsubscribed { get; set; }

    [JsonPropertyName("spammed")]
    public long Spammed { get; set; }

    [JsonPropertyName("dropped")]
    public long Dropped { get; set; }

    [JsonPropertyName("converted")]
    public long Converted { get; set; }
}

public class NewsletterMessagesResponse
{
    [JsonPropertyName("messages")]
    public IEnumerable<NewsletterMessageEntry> Messages { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class NewsletterMessageEntry
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("metric")]
    public string Metric { get; set; } = null!;

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }
}
