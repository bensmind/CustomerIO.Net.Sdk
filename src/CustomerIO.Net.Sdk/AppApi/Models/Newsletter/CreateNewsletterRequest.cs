using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Newsletter;

public class CreateNewsletterRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>The sender identity ID.</summary>
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
}
