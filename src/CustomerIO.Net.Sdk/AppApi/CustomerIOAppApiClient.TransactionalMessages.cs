using CustomerIO.Net.Sdk.AppApi.Models.TransactionalMessage;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all transactional message templates in the workspace.
    /// </summary>
    public async Task<TransactionalMessagesResponse> ListTransactionalMessagesAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/transactional";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TransactionalMessagesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get a specific transactional message template.
    /// </summary>
    public async Task<TransactionalMessageDetailResponse> GetTransactionalMessageAsync(int transactionalId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/transactional/{transactionalId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TransactionalMessageDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get aggregate delivery metrics for a transactional message template.
    /// </summary>
    public async Task<TransactionalMessageMetricsResponse> GetTransactionalMessageMetricsAsync(int transactionalId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/transactional/{transactionalId}/metrics");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TransactionalMessageMetricsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the individual deliveries sent from a transactional message template.
    /// </summary>
    public async Task<TransactionalMessageDeliveriesResponse> GetTransactionalMessageDeliveriesAsync(int transactionalId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/transactional/{transactionalId}/messages";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TransactionalMessageDeliveriesResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
