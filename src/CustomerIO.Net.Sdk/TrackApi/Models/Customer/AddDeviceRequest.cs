using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Customer;

public class AddDeviceRequest
{
    [JsonPropertyName("device")]
    public DeviceRequest Device { get; set; } = null!;
}
