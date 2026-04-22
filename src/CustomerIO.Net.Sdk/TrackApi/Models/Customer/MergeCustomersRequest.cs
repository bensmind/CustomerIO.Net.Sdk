using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Customer;

public class MergeCustomersRequest
{
    /// <summary>
    /// The person that remains after the merge. This profile receives the secondary person's information.
    /// Only one identifier property should be set.
    /// </summary>
    [JsonPropertyName("primary")]
    public CustomerIdentifier Primary { get; set; } = null!;

    /// <summary>
    /// The person that is deleted after the merge. Their information is merged into the primary profile.
    /// Only one identifier property should be set.
    /// </summary>
    [JsonPropertyName("secondary")]
    public CustomerIdentifier Secondary { get; set; } = null!;
}
