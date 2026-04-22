using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Customer;

public class UnsubscribeRequest
{
    /// <summary>
    /// If true, sets the person's unsubscribed attribute to true and attributes the
    /// unsubscription to the delivery referenced in the request path.
    /// </summary>
    [JsonPropertyName("unsubscribe")]
    public bool Unsubscribe { get; set; }
}
