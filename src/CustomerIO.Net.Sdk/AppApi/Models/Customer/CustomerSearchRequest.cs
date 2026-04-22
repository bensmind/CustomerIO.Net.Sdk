using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Customer;

public class CustomerSearchRequest
{
    /// <summary>
    /// Filter expression to select customers.
    /// </summary>
    [JsonPropertyName("filter")]
    public object Filter { get; set; } = null!;
}

public class CustomerSearchResponse
{
    [JsonPropertyName("ids")]
    public IEnumerable<string> Ids { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}
