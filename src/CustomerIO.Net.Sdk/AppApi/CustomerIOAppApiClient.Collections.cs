using CustomerIO.Net.Sdk.AppApi.Models.Collection;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all collections in the workspace.
    /// </summary>
    public async Task<CollectionsResponse> ListCollectionsAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/collections";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CollectionsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Create a new collection. Supply inline <c>Data</c> or a public <c>Url</c> to a CSV/JSON file.
    /// </summary>
    public async Task<CollectionDetailResponse> CreateCollectionAsync(CreateCollectionRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/collections");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CollectionDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific collection.
    /// </summary>
    public async Task<CollectionDetailResponse> GetCollectionAsync(int collectionId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/collections/{collectionId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CollectionDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Delete a collection.
    /// </summary>
    public async Task DeleteCollectionAsync(int collectionId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Delete, $"/v1/collections/{collectionId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Update the metadata or content of a collection.
    /// </summary>
    public async Task<CollectionDetailResponse> UpdateCollectionAsync(int collectionId, UpdateCollectionRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Put, $"/v1/collections/{collectionId}");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CollectionDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
