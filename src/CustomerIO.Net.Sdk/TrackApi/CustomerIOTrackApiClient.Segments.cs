using CustomerIO.Net.Sdk.TrackApi.Models.Segment;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.TrackApi;

public partial class CustomerIOTrackApiClient
{
    /// <summary>
    /// Add people to a manual segment by their identifiers. Limited to 1000 per request.
    /// The segment must already exist.
    /// </summary>
    /// <param name="segmentId">The ID of the segment.</param>
    /// <param name="request">The identifiers to add.</param>
    /// <param name="idType">The type of identifier in the ids array. Use <see cref="SegmentIdType"/> constants. Defaults to "id".</param>
    public async Task AddCustomersToSegmentAsync(int segmentId, SegmentMembersRequest request, string? idType = null, CancellationToken cancellationToken = default)
    {
        var url = $"/api/v1/segments/{segmentId}/add_customers";
        if (!string.IsNullOrEmpty(idType))
            url += $"?id_type={Uri.EscapeDataString(idType)}";

        var req = BuildBaseRequest(HttpMethod.Post, url);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Remove people from a manual segment by their identifiers. Limited to 1000 per request.
    /// </summary>
    /// <param name="segmentId">The ID of the segment.</param>
    /// <param name="request">The identifiers to remove.</param>
    /// <param name="idType">The type of identifier in the ids array. Use <see cref="SegmentIdType"/> constants. Defaults to "id".</param>
    public async Task RemoveCustomersFromSegmentAsync(int segmentId, SegmentMembersRequest request, string? idType = null, CancellationToken cancellationToken = default)
    {
        var url = $"/api/v1/segments/{segmentId}/remove_customers";
        if (!string.IsNullOrEmpty(idType))
            url += $"?id_type={Uri.EscapeDataString(idType)}";

        var req = BuildBaseRequest(HttpMethod.Post, url);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
