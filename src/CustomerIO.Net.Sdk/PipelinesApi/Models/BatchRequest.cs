using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Request body for the <c>POST /v1/batch</c> endpoint.
/// Batches multiple Pipelines API calls into a single HTTP request.
/// </summary>
/// <remarks>
/// Limits: 500 KB per batch request, 32 KB per individual call within the batch.
/// Include only <see cref="IdentifyRequest"/>, <see cref="TrackRequest"/>,
/// <see cref="PageRequest"/>, <see cref="ScreenRequest"/>, and <see cref="GroupRequest"/>
/// items — <see cref="AliasRequest"/> is not supported in batch.
/// </remarks>
public class BatchRequest
{
    /// <summary>
    /// The list of calls to execute. Each item must be an
    /// <see cref="IdentifyRequest"/>, <see cref="TrackRequest"/>,
    /// <see cref="PageRequest"/>, <see cref="ScreenRequest"/>, or
    /// <see cref="GroupRequest"/>.
    /// </summary>
    [JsonPropertyName("batch")]
    public required IEnumerable<PipelinesCallBase> Batch { get; set; }

    /// <summary>
    /// Context properties to apply to all calls in the batch.
    /// </summary>
    [JsonPropertyName("context")]
    public PipelinesContext? Context { get; set; }

    /// <summary>
    /// Integration flags to apply to all calls in the batch.
    /// </summary>
    [JsonPropertyName("integrations")]
    public Dictionary<string, bool>? Integrations { get; set; }
}
