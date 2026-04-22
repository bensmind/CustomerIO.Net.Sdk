using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Transactional;

public class SendPushRequest
{
    /// <summary>
    /// The numerical ID or Trigger Name of the transactional push template to use.
    /// </summary>
    [JsonPropertyName("transactional_message_id")]
    public object TransactionalMessageId { get; set; } = null!;

    /// <summary>
    /// Identifies the person represented by this message. Only one identifier should be set.
    /// </summary>
    [JsonPropertyName("identifiers")]
    public TransactionalIdentifiers Identifiers { get; set; } = null!;

    /// <summary>
    /// The device(s) to send to: "all", "last_used", or a specific device token. Defaults to "all".
    /// </summary>
    [JsonPropertyName("to")]
    public string? To { get; set; }

    /// <summary>
    /// The push notification title. Overrides the template title.
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// The push notification body. Overrides the template body.
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// An image URL to show in the push notification.
    /// </summary>
    [JsonPropertyName("image_url")]
    public string? ImageUrl { get; set; }

    /// <summary>
    /// A deep link to open when the push is tapped.
    /// </summary>
    [JsonPropertyName("link")]
    public string? Link { get; set; }

    /// <summary>
    /// For iOS only: "default" plays the default sound, "none" plays no sound.
    /// </summary>
    [JsonPropertyName("sound")]
    public string? Sound { get; set; }

    /// <summary>
    /// Optional key/value pairs to attach to the push payload. Values must be strings.
    /// </summary>
    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

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
