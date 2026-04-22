using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Collection;

public class CollectionsResponse
{
    [JsonPropertyName("collections")]
    public IEnumerable<CollectionDetail> Collections { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class CollectionDetailResponse
{
    [JsonPropertyName("collection")]
    public CollectionDetail Collection { get; set; } = null!;
}

public class CollectionDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("schema")]
    public Dictionary<string, string>? Schema { get; set; }

    [JsonPropertyName("created")]
    public long Created { get; set; }

    [JsonPropertyName("updated")]
    public long Updated { get; set; }
}

public class CollectionContentResponse
{
    [JsonPropertyName("content")]
    public IEnumerable<Dictionary<string, object?>> Content { get; set; } = [];
}

public class CreateCollectionRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    /// <summary>
    /// A URL pointing to a publicly accessible CSV or JSON file to use as the collection data.
    /// </summary>
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    /// <summary>
    /// Inline data for the collection as an array of objects.
    /// </summary>
    [JsonPropertyName("data")]
    public IEnumerable<Dictionary<string, object?>>? Data { get; set; }
}

public class UpdateCollectionRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("data")]
    public IEnumerable<Dictionary<string, object?>>? Data { get; set; }
}
