using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Snippet;

public class SnippetsResponse
{
    [JsonPropertyName("snippets")]
    public IEnumerable<SnippetDetail> Snippets { get; set; } = [];
}

public class SnippetDetail
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("value")]
    public string Value { get; set; } = null!;
}

public class CreateSnippetRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("value")]
    public string Value { get; set; } = null!;
}

/// <summary>
/// Used for PUT /v1/snippets — replaces an existing snippet by name.
/// </summary>
public class UpdateSnippetRequest
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("value")]
    public string Value { get; set; } = null!;
}
