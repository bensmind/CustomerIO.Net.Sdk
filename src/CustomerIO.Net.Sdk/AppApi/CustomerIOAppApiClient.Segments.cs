using CustomerIO.Net.Sdk.AppApi.Models.Segment;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// Create a new manual segment.
    /// </summary>
    public async Task<SegmentResponse> CreateSegmentAsync(CreateSegmentRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/segments");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// List all segments in the workspace.
    /// </summary>
    public async Task<SegmentsResponse> ListSegmentsAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/segments";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific segment.
    /// </summary>
    public async Task<SegmentResponse> GetSegmentAsync(int segmentId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/segments/{segmentId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Delete a manual segment.
    /// </summary>
    public async Task DeleteSegmentAsync(int segmentId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Delete, $"/v1/segments/{segmentId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Get the number of customers in a segment.
    /// </summary>
    public async Task<SegmentCustomerCountResponse> GetSegmentCustomerCountAsync(int segmentId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/segments/{segmentId}/customer_count");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentCustomerCountResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the IDs of customers who are members of a segment.
    /// </summary>
    public async Task<SegmentMembershipResponse> GetSegmentMembershipAsync(int segmentId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/segments/{segmentId}/membership";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentMembershipResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
