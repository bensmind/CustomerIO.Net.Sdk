using CustomerIO.Net.Sdk.AppApi.Models.Export;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all exports in the workspace.
    /// </summary>
    public async Task<ExportsResponse> ListExportsAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/exports";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ExportsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the status of a specific export.
    /// </summary>
    public async Task<ExportDetailResponse> GetExportAsync(int exportId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/exports/{exportId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ExportDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get a time-limited download URL for a completed export.
    /// </summary>
    public async Task<ExportDownloadResponse> GetExportDownloadUrlAsync(int exportId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/exports/{exportId}/download");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ExportDownloadResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Start an export of customer profile data.
    /// </summary>
    public async Task<ExportDetailResponse> ExportCustomersAsync(ExportCustomersRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/exports/customers");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ExportDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Start an export of delivery data.
    /// </summary>
    public async Task<ExportDetailResponse> ExportDeliveriesAsync(ExportDeliveriesRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/exports/deliveries");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<ExportDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
