using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Request body for the <c>POST /v1/group</c> endpoint.
/// Associates a person with an object/group and sets traits on that object.
/// </summary>
public class GroupRequest : PipelinesCallBase
{
    /// <summary>
    /// The unique identifier of the group or object. Required.
    /// </summary>
    [JsonPropertyName("groupId")]
    public required string GroupId { get; set; }

    /// <summary>
    /// A dictionary of traits to set on the group/object, such as its name,
    /// industry, employee count, or any custom attributes.
    /// </summary>
    [JsonPropertyName("traits")]
    public Dictionary<string, object?>? Traits { get; set; }
}
