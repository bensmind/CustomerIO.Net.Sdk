using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Transactional;

public class SendInboxMessageRequest
{
    /// <summary>
    /// The numerical ID or Trigger Name of the transactional in-app message template to use.
    /// </summary>
    [JsonPropertyName("transactional_message_id")]
    public object TransactionalMessageId { get; set; } = null!;

    /// <summary>
    /// Identifies the person represented by this message. Only one identifier should be set.
    /// </summary>
    [JsonPropertyName("identifiers")]
    public TransactionalIdentifiers Identifiers { get; set; } = null!;

    /// <summary>
    /// Key-value pairs referenced as liquid in the message via {{trigger.&lt;key&gt;}}.
    /// </summary>
    [JsonPropertyName("message_data")]
    public Dictionary<string, object?>? MessageData { get; set; }

    /// <summary>
    /// Unix timestamp for when to send the message. Up to 90 days in the future.
    /// </summary>
    [JsonPropertyName("send_at")]
    public long? SendAt { get; set; }

    /// <summary>
    /// If true, the message body is not retained in delivery history.
    /// </summary>
    [JsonPropertyName("disable_message_retention")]
    public bool? DisableMessageRetention { get; set; }

    /// <summary>
    /// If false, the message is not sent to unsubscribed recipients.
    /// </summary>
    [JsonPropertyName("send_to_unsubscribed")]
    public bool? SendToUnsubscribed { get; set; }

    /// <summary>
    /// If true, the message is held as a draft and must be manually sent from the UI.
    /// </summary>
    [JsonPropertyName("queue_draft")]
    public bool? QueueDraft { get; set; }

    /// <summary>
    /// Overrides language preferences for the recipient.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }
}
