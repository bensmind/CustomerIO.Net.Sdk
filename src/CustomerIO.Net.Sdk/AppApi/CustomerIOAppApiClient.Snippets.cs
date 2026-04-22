using CustomerIO.Net.Sdk.AppApi.Models.Snippet;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all snippets in the workspace.
    /// </summary>
    public async Task<SnippetsResponse> ListSnippetsAsync(CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, "/v1/snippets");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SnippetsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Create a new snippet.
    /// </summary>
    public async Task<SnippetDetail> CreateSnippetAsync(CreateSnippetRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/snippets");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SnippetDetail>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Update an existing snippet by name.
    /// </summary>
    public async Task<SnippetDetail> UpdateSnippetAsync(UpdateSnippetRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Put, "/v1/snippets");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SnippetDetail>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Delete a snippet by name.
    /// </summary>
    public async Task DeleteSnippetAsync(string snippetName, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Delete, $"/v1/snippets/{Uri.EscapeDataString(snippetName)}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
