using CustomerIO.Net.Sdk.AppApi.Models.Message;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// List message deliveries across all channels.
    /// </summary>
    public async Task<MessagesResponse> ListMessagesAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/messages";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<MessagesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific message delivery.
    /// </summary>
    public async Task<MessageDetailResponse> GetMessageAsync(string messageId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/messages/{Uri.EscapeDataString(messageId)}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<MessageDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
