using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Customer;

public class DeviceRequest
{
    /// <summary>
    /// The device token used to send push notifications.
    /// </summary>
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    /// <summary>
    /// The device platform. Use <see cref="DevicePlatform"/> constants.
    /// </summary>
    [JsonPropertyName("platform")]
    public string Platform { get; set; } = null!;

    /// <summary>
    /// Unix timestamp of when the device was last used. Defaults to the time of the request.
    /// </summary>
    [JsonPropertyName("last_used")]
    public long? LastUsed { get; set; }

    [JsonPropertyName("attributes")]
    public DeviceAttributes? Attributes { get; set; }
}

public static class DevicePlatform
{
    public const string Ios = "ios";
    public const string Android = "android";
}
