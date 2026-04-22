using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Message;

public class MessagesResponse
{
    [JsonPropertyName("messages")]
    public IEnumerable<MessageDetail> Messages { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class MessageDetailResponse
{
    [JsonPropertyName("message")]
    public MessageDetail Message { get; set; } = null!;
}

public class MessageDetail
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>e.g. "email", "push", "sms", "in_app", "webhook"</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>e.g. "sent", "delivered", "opened", "clicked", "bounced", "failed"</summary>
    [JsonPropertyName("metric")]
    public string Metric { get; set; } = null!;

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    [JsonPropertyName("body_url")]
    public string? BodyUrl { get; set; }

    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    [JsonPropertyName("customer_id")]
    public string? CustomerId { get; set; }
}
