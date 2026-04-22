using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Segment;

public class SegmentCustomerCountResponse
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class SegmentMembershipResponse
{
    [JsonPropertyName("ids")]
    public IEnumerable<string> Ids { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
