using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Request body for the <c>POST /v1/screen</c> endpoint.
/// Records a mobile screen view, including the name of the screen.
/// </summary>
public class ScreenRequest : PipelinesCallBase
{
    /// <summary>
    /// The name of the screen the person viewed.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// A dictionary of additional properties about the screen view.
    /// </summary>
    [JsonPropertyName("properties")]
    public Dictionary<string, object?>? Properties { get; set; }
}
