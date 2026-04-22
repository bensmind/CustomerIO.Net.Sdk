using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Campaign;

public class CampaignActionsResponse
{
    [JsonPropertyName("actions")]
    public IEnumerable<CampaignActionDetail> Actions { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class CampaignActionResponse
{
    [JsonPropertyName("action")]
    public CampaignActionDetail Action { get; set; } = null!;
}

public class CampaignActionDetail
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("campaign_id")]
    public int CampaignId { get; set; }

    /// <summary>e.g. "email", "push", "sms", "in_app", "webhook"</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("sending_state")]
    public string? SendingState { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; set; }
}

public class UpdateCampaignActionRequest
{
    /// <summary>
    /// The body/content of the action. Structure varies by type.
    /// </summary>
    [JsonPropertyName("body")]
    public string? Body { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("from")]
    public string? From { get; set; }

    [JsonPropertyName("reply_to")]
    public string? ReplyTo { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
