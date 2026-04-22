using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.TransactionalMessage;

public class TransactionalMessagesResponse
{
    [JsonPropertyName("messages")]
    public IEnumerable<TransactionalMessageDetail> Messages { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class TransactionalMessageDetailResponse
{
    [JsonPropertyName("message")]
    public TransactionalMessageDetail Message { get; set; } = null!;
}

public class TransactionalMessageDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>The trigger name assigned in the UI.</summary>
    [JsonPropertyName("trigger_name")]
    public string? TriggerName { get; set; }

    /// <summary>e.g. "email", "push", "sms", "in_app"</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("from_id")]
    public int? FromId { get; set; }

    [JsonPropertyName("reply_to_id")]
    public int? ReplyToId { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("updated")]
    public long Updated { get; set; }
}

public class TransactionalMessageMetricsResponse
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

    [JsonPropertyName("attempted")]
    public long Attempted { get; set; }

    [JsonPropertyName("failed")]
    public long Failed { get; set; }
}

public class TransactionalMessageDeliveriesResponse
{
    [JsonPropertyName("messages")]
    public IEnumerable<TransactionalMessageDeliveryEntry> Messages { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class TransactionalMessageDeliveryEntry
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
