using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Broadcast;

public class BroadcastTriggersResponse
{
    [JsonPropertyName("triggers")]
    public IEnumerable<BroadcastTriggerDetail> Triggers { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class BroadcastTriggerDetailResponse
{
    [JsonPropertyName("trigger")]
    public BroadcastTriggerDetail Trigger { get; set; } = null!;
}

public class BroadcastTriggerDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>e.g. "pending", "running", "finished", "errored", "stopped"</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; set; }

    [JsonPropertyName("errors")]
    public IEnumerable<BroadcastTriggerError>? Errors { get; set; }
}

public class BroadcastTriggerErrorsResponse
{
    [JsonPropertyName("errors")]
    public IEnumerable<BroadcastTriggerError> Errors { get; set; } = [];
}

public class BroadcastTriggerError
{
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("emails")]
    public IEnumerable<string>? Emails { get; set; }

    [JsonPropertyName("ids")]
    public IEnumerable<string>? Ids { get; set; }
}

public class BroadcastMetricsResponse
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

public class BroadcastMessagesResponse
{
    [JsonPropertyName("messages")]
    public IEnumerable<BroadcastMessageEntry> Messages { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class BroadcastMessageEntry
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
