using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Segment;

public class CreateSegmentRequest
{
    /// <summary>
    /// The name of the segment.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// An optional description of the segment.
    /// </summary>
    [JsonPropertyName("description")]
    public string? Description { get; set; }
}
