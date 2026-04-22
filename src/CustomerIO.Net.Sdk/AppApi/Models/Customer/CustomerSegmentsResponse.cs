using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Customer;

public class CustomerSegmentsResponse
{
    [JsonPropertyName("segments")]
    public IEnumerable<CustomerSegmentEntry> Segments { get; set; } = [];
}

public class CustomerSegmentEntry
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;
}
