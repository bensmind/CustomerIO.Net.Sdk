using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Event;

public class MetricsRequest
{
    /// <summary>
    /// The CIO-Delivery-ID from the notification to associate the metric with.
    /// </summary>
    [JsonPropertyName("delivery_id")]
    public string DeliveryId { get; set; } = null!;

    /// <summary>
    /// The metric to report. Use <see cref="MetricType"/> constants, or channel-specific subsets.
    /// </summary>
    [JsonPropertyName("metric")]
    public string Metric { get; set; } = null!;

    /// <summary>
    /// Unix timestamp when the event occurred.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }

    /// <summary>
    /// The recipient of the message (email address, phone number, or device ID depending on channel).
    /// </summary>
    [JsonPropertyName("recipient")]
    public string? Recipient { get; set; }

    /// <summary>
    /// For failure metrics (e.g. bounced), the reason for the failure.
    /// </summary>
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }

    /// <summary>
    /// For clicked metrics, the link the recipient clicked.
    /// </summary>
    [JsonPropertyName("href")]
    public string? Href { get; set; }
}

public static class MetricType
{
    public const string Bounced = "bounced";
    public const string Clicked = "clicked";
    public const string Converted = "converted";
    public const string Deferred = "deferred";
    public const string Delivered = "delivered";
    public const string Dropped = "dropped";
    public const string Opened = "opened";
    public const string Spammed = "spammed";
}
