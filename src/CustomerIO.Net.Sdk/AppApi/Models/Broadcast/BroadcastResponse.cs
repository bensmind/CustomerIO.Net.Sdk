using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Broadcast;

public class BroadcastsResponse
{
    [JsonPropertyName("broadcasts")]
    public IEnumerable<BroadcastDetail> Broadcasts { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class BroadcastResponse
{
    [JsonPropertyName("broadcast")]
    public BroadcastDetail Broadcast { get; set; } = null!;
}

public class BroadcastDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    /// <summary>e.g. "draft", "running", "stopped", "finished"</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    [JsonPropertyName("start_time")]
    public long? StartTime { get; set; }

    [JsonPropertyName("tags")]
    public IEnumerable<string>? Tags { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("updated")]
    public long Updated { get; set; }
}
