using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Customer;

public class DeviceAttributes
{
    [JsonPropertyName("device_os")]
    public string? DeviceOs { get; set; }

    [JsonPropertyName("device_model")]
    public string? DeviceModel { get; set; }

    [JsonPropertyName("app_version")]
    public string? AppVersion { get; set; }

    [JsonPropertyName("cio_sdk_version")]
    public string? CioSdkVersion { get; set; }

    /// <summary>
    /// Whether push notifications are enabled. Must be "true" or "false".
    /// </summary>
    [JsonPropertyName("push_enabled")]
    public string? PushEnabled { get; set; }

    /// <summary>
    /// Custom device attributes. Values must be strings.
    /// </summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? CustomAttributes { get; set; }
}
