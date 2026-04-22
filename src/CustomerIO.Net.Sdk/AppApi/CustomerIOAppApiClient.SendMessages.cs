using CustomerIO.Net.Sdk.AppApi.Models.Broadcast;
using CustomerIO.Net.Sdk.AppApi.Models.Newsletter;
using CustomerIO.Net.Sdk.AppApi.Models.Transactional;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
    /// <summary>
    /// Send a transactional email to a customer. Use a template or provide <c>body</c>,
    /// <c>subject</c>, and <c>from</c> inline — inline values override the template.
    /// Rate limited to 100 requests per second.
    /// </summary>
    public async Task<TransactionalDeliveryResponse> SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/send/email");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TransactionalDeliveryResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Send a transactional push notification to a customer.
    /// Rate limited to 100 requests per second.
    /// </summary>
    public async Task<TransactionalDeliveryResponse> SendPushAsync(SendPushRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/send/push");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TransactionalDeliveryResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Send a transactional SMS to a customer.
    /// Rate limited to 100 requests per second.
    /// </summary>
    public async Task<TransactionalDeliveryResponse> SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/send/sms");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TransactionalDeliveryResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Send a transactional in-app inbox message to a customer.
    /// Rate limited to 100 requests per second.
    /// </summary>
    public async Task<TransactionalDeliveryResponse> SendInboxMessageAsync(SendInboxMessageRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/send/inbox_message");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TransactionalDeliveryResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Trigger an API-triggered broadcast. Optionally restrict to a segment or supply
    /// per-recipient data via <c>PerUserData</c>.
    /// Rate limited to 1 request per 10 seconds per broadcast.
    /// </summary>
    public async Task<TriggerBroadcastResponse> TriggerBroadcastAsync(int broadcastId, TriggerBroadcastRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/v1/campaigns/{broadcastId}/triggers");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<TriggerBroadcastResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Send a draft newsletter immediately to all configured recipients.
    /// </summary>
    public async Task<NewsletterResponse> SendNewsletterAsync(int newsletterId, SendNewsletterRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/v1/newsletters/{newsletterId}/send");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<NewsletterResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Schedule a draft newsletter to send at a future time. If already scheduled,
    /// this updates the scheduled time. Set <c>ScheduledAt</c> to <c>0</c> to deschedule.
    /// </summary>
    public async Task<NewsletterResponse> ScheduleNewsletterAsync(int newsletterId, ScheduleNewsletterRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/v1/newsletters/{newsletterId}/schedule");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<NewsletterResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
