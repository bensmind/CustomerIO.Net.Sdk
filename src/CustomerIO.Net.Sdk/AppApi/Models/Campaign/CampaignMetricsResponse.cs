using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Campaign;

public class CampaignMetricsResponse
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

public class CampaignMessagesResponse
{
    [JsonPropertyName("messages")]
    public IEnumerable<CampaignMessageEntry> Messages { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class CampaignMessageEntry
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
