using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Request body for the <c>POST /v1/track</c> endpoint.
/// Records a named action that a person performs, along with optional properties.
/// </summary>
public class TrackRequest : PipelinesCallBase
{
    /// <summary>
    /// The name of the event. Required.
    /// </summary>
    [JsonPropertyName("event")]
    public required string Event { get; set; }

    /// <summary>
    /// A dictionary of properties providing additional context about the event,
    /// such as revenue, a product name, or an order ID.
    /// </summary>
    [JsonPropertyName("properties")]
    public Dictionary<string, object?>? Properties { get; set; }
}

/// <summary>
/// Semantic event names for managing people and devices via <c>POST /v1/track</c>.
/// Sending a <see cref="TrackRequest"/> with one of these event names triggers
/// the corresponding operation in Customer.io.
/// </summary>
public static class PipelinesSemanticEvents
{
    /// <summary>Creates or updates a mobile device token for a person.</summary>
    public const string DeviceCreatedOrUpdated = "Device Created or Updated";

    /// <summary>Deletes a mobile device token from a person's profile.</summary>
    public const string DeviceDeleted = "Device Deleted";

    /// <summary>Removes a person and all their data from Customer.io.</summary>
    public const string UserDeleted = "User Deleted";

    /// <summary>Suppresses a person, preventing messages from being sent to them.</summary>
    public const string UserSuppressed = "User Suppressed";

    /// <summary>Unsuppresses a previously suppressed person.</summary>
    public const string UserUnsuppressed = "User Unsuppressed";

    /// <summary>Removes the relationship between a person and an object/group.</summary>
    public const string RelationshipDeleted = "Relationship Deleted";

    /// <summary>Removes an object/group from Customer.io.</summary>
    public const string ObjectDeleted = "Object Deleted";

    /// <summary>Reports a delivery event metric back to Customer.io.</summary>
    public const string ReportDeliveryEvent = "Report Delivery Event";
}
