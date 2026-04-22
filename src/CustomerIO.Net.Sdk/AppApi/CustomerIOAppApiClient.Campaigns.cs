using CustomerIO.Net.Sdk.AppApi.Models.Campaign;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all campaigns in the workspace.
    /// </summary>
    public async Task<CampaignsResponse> ListCampaignsAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/campaigns";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CampaignsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific campaign.
    /// </summary>
    public async Task<CampaignResponse> GetCampaignAsync(int campaignId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/campaigns/{campaignId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CampaignResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get aggregate delivery metrics for a campaign.
    /// </summary>
    public async Task<CampaignMetricsResponse> GetCampaignMetricsAsync(int campaignId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/campaigns/{campaignId}/metrics");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CampaignMetricsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the message deliveries sent by a campaign.
    /// </summary>
    public async Task<CampaignMessagesResponse> GetCampaignMessagesAsync(int campaignId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/campaigns/{campaignId}/messages";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CampaignMessagesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// List the actions (messages, webhooks, etc.) within a campaign.
    /// </summary>
    public async Task<CampaignActionsResponse> ListCampaignActionsAsync(int campaignId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/campaigns/{campaignId}/actions";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CampaignActionsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific campaign action.
    /// </summary>
    public async Task<CampaignActionResponse> GetCampaignActionAsync(int campaignId, string actionId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/campaigns/{campaignId}/actions/{Uri.EscapeDataString(actionId)}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CampaignActionResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Update a campaign action (e.g. change the email subject or body).
    /// </summary>
    public async Task<CampaignActionResponse> UpdateCampaignActionAsync(int campaignId, string actionId, UpdateCampaignActionRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Put, $"/v1/campaigns/{campaignId}/actions/{Uri.EscapeDataString(actionId)}");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CampaignActionResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
