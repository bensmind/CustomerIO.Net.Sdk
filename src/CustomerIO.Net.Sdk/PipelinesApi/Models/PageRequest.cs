using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Request body for the <c>POST /v1/page</c> endpoint.
/// Records a pageview, including the name of the page and URL properties.
/// </summary>
public class PageRequest : PipelinesCallBase
{
    /// <summary>
    /// The name of the page.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Properties of the page. Common keys: <c>url</c>, <c>title</c>,
    /// <c>referrer</c>, <c>path</c>, <c>search</c>.
    /// </summary>
    [JsonPropertyName("properties")]
    public Dictionary<string, object?>? Properties { get; set; }
}
