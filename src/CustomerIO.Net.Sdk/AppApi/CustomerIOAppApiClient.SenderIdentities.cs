using CustomerIO.Net.Sdk.AppApi.Models.SenderIdentity;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List all sender identities (from addresses) in the workspace.
    /// </summary>
    public async Task<SenderIdentitiesResponse> ListSenderIdentitiesAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/sender_identities";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SenderIdentitiesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific sender identity.
    /// </summary>
    public async Task<SenderIdentityDetailResponse> GetSenderIdentityAsync(int senderId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/sender_identities/{senderId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SenderIdentityDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
