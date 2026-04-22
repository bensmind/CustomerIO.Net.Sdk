using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Request body for the <c>POST /v1/identify</c> endpoint.
/// Creates or updates a person and sets traits on their profile.
/// </summary>
public class IdentifyRequest : PipelinesCallBase
{
    /// <summary>
    /// A dictionary of traits you know about the person, such as their email,
    /// name, created-at date, or any custom attributes.
    /// Common reserved trait names: <c>email</c>, <c>name</c>, <c>phone</c>,
    /// <c>avatar</c>, <c>birthday</c>, <c>createdAt</c>, <c>address</c>.
    /// </summary>
    [JsonPropertyName("traits")]
    public Dictionary<string, object?>? Traits { get; set; }
}
