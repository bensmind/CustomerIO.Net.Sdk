using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Campaign;

public class CampaignsResponse
{
    [JsonPropertyName("campaigns")]
    public IEnumerable<CampaignDetail> Campaigns { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class CampaignResponse
{
    [JsonPropertyName("campaign")]
    public CampaignDetail Campaign { get; set; } = null!;
}

public class CampaignDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>e.g. "triggered", "scheduled", "api"</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>e.g. "draft", "stopped", "running"</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("msg_id")]
    public string? MsgId { get; set; }

    [JsonPropertyName("start_time")]
    public long? StartTime { get; set; }

    [JsonPropertyName("stop_time")]
    public long? StopTime { get; set; }

    [JsonPropertyName("frequency")]
    public string? Frequency { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("updated")]
    public long Updated { get; set; }
}
