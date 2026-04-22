using CustomerIO.Net.Sdk.AppApi.Models.Newsletter;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all newsletters in the workspace.
    /// </summary>
    public async Task<NewslettersResponse> ListNewslettersAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/newsletters";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<NewslettersResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Create a new newsletter.
    /// </summary>
    public async Task<NewsletterResponse> CreateNewsletterAsync(CreateNewsletterRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/newsletters");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<NewsletterResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific newsletter.
    /// </summary>
    public async Task<NewsletterResponse> GetNewsletterAsync(int newsletterId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/newsletters/{newsletterId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<NewsletterResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Delete a newsletter. Only unsent newsletters can be deleted.
    /// </summary>
    public async Task DeleteNewsletterAsync(int newsletterId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Delete, $"/v1/newsletters/{newsletterId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Get aggregate delivery metrics for a newsletter.
    /// </summary>
    public async Task<NewsletterMetricsResponse> GetNewsletterMetricsAsync(int newsletterId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/newsletters/{newsletterId}/metrics");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<NewsletterMetricsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the individual deliveries sent by a newsletter.
    /// </summary>
    public async Task<NewsletterMessagesResponse> GetNewsletterMessagesAsync(int newsletterId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/newsletters/{newsletterId}/messages";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<NewsletterMessagesResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
