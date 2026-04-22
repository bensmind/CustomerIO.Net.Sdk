using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Segment;

public class SegmentResponse
{
    [JsonPropertyName("segment")]
    public SegmentDetail Segment { get; set; } = null!;
}

public class SegmentsResponse
{
    [JsonPropertyName("segments")]
    public IEnumerable<SegmentDetail> Segments { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class SegmentDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// The segment type: "manual" or "dynamic".
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; set; }
}

public static class SegmentType
{
    public const string Manual = "manual";
    public const string Dynamic = "dynamic";
}
