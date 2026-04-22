using CustomerIO.Net.Sdk.AppApi.Models.ReportingWebhook;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all reporting webhooks in the workspace.
    /// </summary>
    public async Task<ReportingWebhooksResponse> ListReportingWebhooksAsync(CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, "/v1/reporting_webhooks");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ReportingWebhooksResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Create a new reporting webhook that notifies an external URL of delivery events.
    /// </summary>
    public async Task<ReportingWebhookDetailResponse> CreateReportingWebhookAsync(CreateReportingWebhookRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/reporting_webhooks");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ReportingWebhookDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific reporting webhook.
    /// </summary>
    public async Task<ReportingWebhookDetailResponse> GetReportingWebhookAsync(int webhookId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/reporting_webhooks/{webhookId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ReportingWebhookDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Update a reporting webhook's endpoint URL, events, or enabled state.
    /// </summary>
    public async Task<ReportingWebhookDetailResponse> UpdateReportingWebhookAsync(int webhookId, UpdateReportingWebhookRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Put, $"/v1/reporting_webhooks/{webhookId}");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ReportingWebhookDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Delete a reporting webhook.
    /// </summary>
    public async Task DeleteReportingWebhookAsync(int webhookId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Delete, $"/v1/reporting_webhooks/{webhookId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
