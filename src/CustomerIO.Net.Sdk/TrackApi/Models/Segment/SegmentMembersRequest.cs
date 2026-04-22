using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.TrackApi.Models.Segment;

public class SegmentMembersRequest
{
    /// <summary>
    /// The customer identifiers to add to or remove from the segment. Limited to 1000 per request.
    /// The type of identifier corresponds to the id_type parameter passed to the method.
    /// </summary>
    [JsonPropertyName("ids")]
    public IEnumerable<string> Ids { get; set; } = null!;
}

public static class SegmentIdType
{
    public const string Id = "id";
    public const string Email = "email";
    public const string CioId = "cio_id";
}
