using CustomerIO.Net.Sdk.AppApi.Models.Broadcast;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all API-triggered broadcasts in the workspace.
    /// </summary>
    public async Task<BroadcastsResponse> ListBroadcastsAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/broadcasts";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific API-triggered broadcast.
    /// </summary>
    public async Task<BroadcastResponse> GetBroadcastAsync(int broadcastId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/broadcasts/{broadcastId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get aggregate delivery metrics for an API-triggered broadcast.
    /// </summary>
    public async Task<BroadcastMetricsResponse> GetBroadcastMetricsAsync(int broadcastId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/broadcasts/{broadcastId}/metrics");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastMetricsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the message deliveries sent by an API-triggered broadcast.
    /// </summary>
    public async Task<BroadcastMessagesResponse> GetBroadcastMessagesAsync(int broadcastId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/broadcasts/{broadcastId}/messages";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastMessagesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// List all triggers that have been fired for a broadcast.
    /// </summary>
    public async Task<BroadcastTriggersResponse> ListBroadcastTriggersAsync(int broadcastId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/broadcasts/{broadcastId}/triggers";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastTriggersResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the status and details of a specific broadcast trigger.
    /// </summary>
    public async Task<BroadcastTriggerDetailResponse> GetBroadcastTriggerAsync(int broadcastId, int triggerId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/campaigns/{broadcastId}/triggers/{triggerId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastTriggerDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get validation errors for a specific broadcast trigger.
    /// </summary>
    public async Task<BroadcastTriggerErrorsResponse> GetBroadcastTriggerErrorsAsync(int broadcastId, int triggerId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/campaigns/{broadcastId}/triggers/{triggerId}/errors");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastTriggerErrorsResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
