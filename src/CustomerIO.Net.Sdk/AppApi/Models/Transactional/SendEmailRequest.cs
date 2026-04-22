using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Transactional;

public class SendEmailRequest
{
    /// <summary>
    /// The numerical ID or Trigger Name of the transactional message template to use.
    /// </summary>
    [JsonPropertyName("transactional_message_id")]
    public object? TransactionalMessageId { get; set; }

    /// <summary>
    /// The recipient email address(es). Supports multiple addresses separated by commas.
    /// Up to 15 total recipients across to and bcc.
    /// </summary>
    [JsonPropertyName("to")]
    public string To { get; set; } = null!;

    /// <summary>
    /// Identifies the person represented by this message. Only one identifier should be set.
    /// </summary>
    [JsonPropertyName("identifiers")]
    public TransactionalIdentifiers Identifiers { get; set; } = null!;

    /// <summary>
    /// The HTML body of the message. Overrides the template body.
    /// </summary>
    [JsonPropertyName("body")]
    public string? Body { get; set; }

    /// <summary>
    /// AMP-enabled HTML body. If the recipient's email client doesn't support AMP,
    /// the regular body is used as fallback.
    /// </summary>
    [JsonPropertyName("body_amp")]
    public string? BodyAmp { get; set; }

    /// <summary>
    /// The plaintext body of the message. Overrides the template body.
    /// </summary>
    [JsonPropertyName("body_plain")]
    public string? BodyPlain { get; set; }

    /// <summary>
    /// The subject line. Overrides the template subject.
    /// </summary>
    [JsonPropertyName("subject")]
    public string? Subject { get; set; }

    /// <summary>
    /// The from address. Must be verified by Customer.io. Overrides the template from address.
    /// </summary>
    [JsonPropertyName("from")]
    public string? From { get; set; }

    /// <summary>
    /// The reply-to address, if different from the from address.
    /// </summary>
    [JsonPropertyName("reply_to")]
    public string? ReplyTo { get; set; }

    /// <summary>
    /// Blind copy recipient(s). Up to 15 total recipients across to and bcc.
    /// </summary>
    [JsonPropertyName("bcc")]
    public string? Bcc { get; set; }

    /// <summary>
    /// If true, sends a copy with the subject containing the recipient address instead of a true BCC.
    /// </summary>
    [JsonPropertyName("fake_bcc")]
    public bool? FakeBcc { get; set; }

    /// <summary>
    /// Preview text shown in the inbox next to the subject line.
    /// </summary>
    [JsonPropertyName("preheader")]
    public string? Preheader { get; set; }

    /// <summary>
    /// Key-value pairs referenced as liquid in the message via {{trigger.&lt;key&gt;}}.
    /// </summary>
    [JsonPropertyName("message_data")]
    public Dictionary<string, object?>? MessageData { get; set; }

    /// <summary>
    /// Unix timestamp for when to send the message. Up to 90 days in the future.
    /// If in the past, the message is sent immediately.
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
    /// Attachments as a dictionary of filename → base64-encoded content.
    /// Total size must be less than 2MB.
    /// </summary>
    [JsonPropertyName("attachments")]
    public Dictionary<string, string>? Attachments { get; set; }

    /// <summary>
    /// A JSON string containing an array of header objects with name and value properties.
    /// </summary>
    [JsonPropertyName("headers")]
    public string? Headers { get; set; }

    /// <summary>
    /// If true, disables CSS preprocessing. Overrides the template setting.
    /// </summary>
    [JsonPropertyName("disable_css_preprocessing")]
    public bool? DisableCssPreprocessing { get; set; }

    /// <summary>
    /// If true, Customer.io tracks opens and link clicks.
    /// </summary>
    [JsonPropertyName("tracked")]
    public bool? Tracked { get; set; }

    /// <summary>
    /// Overrides language preferences for the recipient.
    /// </summary>
    [JsonPropertyName("language")]
    public string? Language { get; set; }
}
