using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Event;

/// <summary>
/// Request body for reporting push metrics via the legacy push metrics endpoint.
/// </summary>
[Obsolete("Use MetricsRequest with ReportMetricsAsync instead.")]
public class PushMetricsRequest
{
    /// <summary>
    /// The CIO-Delivery-ID from the notification to associate the metric with.
    /// </summary>
    [JsonPropertyName("delivery_id")]
    public string DeliveryId { get; set; } = null!;

    /// <summary>
    /// The type of device-side event. Use <see cref="PushEventType"/> constants.
    /// </summary>
    [JsonPropertyName("event")]
    public string Event { get; set; } = null!;

    /// <summary>
    /// The CIO-Delivery-Token representing the device that received the original notification.
    /// </summary>
    [JsonPropertyName("device_id")]
    public string DeviceId { get; set; } = null!;

    /// <summary>
    /// Unix timestamp when the event occurred.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public long? Timestamp { get; set; }
}

public static class PushEventType
{
    public const string Opened = "opened";
    public const string Converted = "converted";
    public const string Delivered = "delivered";
}
