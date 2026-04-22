using CustomerIO.Net.Sdk.TrackApi.Models.Event;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.TrackApi;

public partial class CustomerIOTrackApiClient
{
    /// <summary>
    /// Track an event associated with a specific customer.
    /// </summary>
    public async Task TrackEventAsync(string identifier, TrackEventRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/api/v1/customers/{Uri.EscapeDataString(identifier)}/events");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Track an anonymous event not yet associated with a known customer. If event merging is enabled
    /// and the anonymous_id matches a person's attribute, the event is associated with that person.
    /// </summary>
    public async Task TrackAnonymousEventAsync(TrackAnonymousEventRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/api/v1/events");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Report a delivery metric back to Customer.io for channels that don't natively report metrics
    /// (e.g. push, in-app). This endpoint does not require authentication.
    /// </summary>
    public async Task ReportMetricsAsync(MetricsRequest request, CancellationToken cancellationToken = default)
    {
        var req = new HttpRequestMessage(HttpMethod.Post, "/api/v1/metrics");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Report a push delivery metric back to Customer.io.
    /// </summary>
    [Obsolete("Use ReportMetricsAsync instead.")]
    public async Task ReportPushMetricsAsync(PushMetricsRequest request, CancellationToken cancellationToken = default)
    {
        var req = new HttpRequestMessage(HttpMethod.Post, "/api/v1/push/events");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
