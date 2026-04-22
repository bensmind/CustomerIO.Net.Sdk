using CustomerIO.Net.Sdk.AppApi.Models.Broadcast;
using CustomerIO.Net.Sdk.AppApi.Models.Campaign;
using CustomerIO.Net.Sdk.AppApi.Models.Collection;
using CustomerIO.Net.Sdk.AppApi.Models.Customer;
using CustomerIO.Net.Sdk.AppApi.Models.Export;
using CustomerIO.Net.Sdk.AppApi.Models.Message;
using CustomerIO.Net.Sdk.AppApi.Models.Newsletter;
using CustomerIO.Net.Sdk.AppApi.Models.ReportingWebhook;
using CustomerIO.Net.Sdk.AppApi.Models.Segment;
using CustomerIO.Net.Sdk.AppApi.Models.SenderIdentity;
using CustomerIO.Net.Sdk.AppApi.Models.Snippet;
using CustomerIO.Net.Sdk.AppApi.Models.TransactionalMessage;
using CustomerIO.Net.Sdk.AppApi.Models.Transactional;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public interface ICustomerIOAppApiClient
{
    // Send Messages
    Task<TransactionalDeliveryResponse> SendEmailAsync(SendEmailRequest request, CancellationToken cancellationToken = default);
    Task<TransactionalDeliveryResponse> SendPushAsync(SendPushRequest request, CancellationToken cancellationToken = default);
    Task<TransactionalDeliveryResponse> SendSmsAsync(SendSmsRequest request, CancellationToken cancellationToken = default);
    Task<TransactionalDeliveryResponse> SendInboxMessageAsync(SendInboxMessageRequest request, CancellationToken cancellationToken = default);
    Task<TriggerBroadcastResponse> TriggerBroadcastAsync(int broadcastId, TriggerBroadcastRequest request, CancellationToken cancellationToken = default);
    Task<NewsletterResponse> SendNewsletterAsync(int newsletterId, SendNewsletterRequest request, CancellationToken cancellationToken = default);
    Task<NewsletterResponse> ScheduleNewsletterAsync(int newsletterId, ScheduleNewsletterRequest request, CancellationToken cancellationToken = default);

    // Campaigns
    Task<CampaignsResponse> ListCampaignsAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<CampaignResponse> GetCampaignAsync(int campaignId, CancellationToken cancellationToken = default);
    Task<CampaignMetricsResponse> GetCampaignMetricsAsync(int campaignId, CancellationToken cancellationToken = default);
    Task<CampaignMessagesResponse> GetCampaignMessagesAsync(int campaignId, string? next = null, CancellationToken cancellationToken = default);
    Task<CampaignActionsResponse> ListCampaignActionsAsync(int campaignId, string? next = null, CancellationToken cancellationToken = default);
    Task<CampaignActionResponse> GetCampaignActionAsync(int campaignId, string actionId, CancellationToken cancellationToken = default);
    Task<CampaignActionResponse> UpdateCampaignActionAsync(int campaignId, string actionId, UpdateCampaignActionRequest request, CancellationToken cancellationToken = default);

    // API-triggered Broadcasts
    Task<BroadcastsResponse> ListBroadcastsAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<BroadcastResponse> GetBroadcastAsync(int broadcastId, CancellationToken cancellationToken = default);
    Task<BroadcastMetricsResponse> GetBroadcastMetricsAsync(int broadcastId, CancellationToken cancellationToken = default);
    Task<BroadcastMessagesResponse> GetBroadcastMessagesAsync(int broadcastId, string? next = null, CancellationToken cancellationToken = default);
    Task<BroadcastTriggersResponse> ListBroadcastTriggersAsync(int broadcastId, string? next = null, CancellationToken cancellationToken = default);
    Task<BroadcastTriggerDetailResponse> GetBroadcastTriggerAsync(int broadcastId, int triggerId, CancellationToken cancellationToken = default);
    Task<BroadcastTriggerErrorsResponse> GetBroadcastTriggerErrorsAsync(int broadcastId, int triggerId, CancellationToken cancellationToken = default);

    // Transactional Messages
    Task<TransactionalMessagesResponse> ListTransactionalMessagesAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<TransactionalMessageDetailResponse> GetTransactionalMessageAsync(int transactionalId, CancellationToken cancellationToken = default);
    Task<TransactionalMessageMetricsResponse> GetTransactionalMessageMetricsAsync(int transactionalId, CancellationToken cancellationToken = default);
    Task<TransactionalMessageDeliveriesResponse> GetTransactionalMessageDeliveriesAsync(int transactionalId, string? next = null, CancellationToken cancellationToken = default);

    // Newsletters
    Task<NewslettersResponse> ListNewslettersAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<NewsletterResponse> CreateNewsletterAsync(CreateNewsletterRequest request, CancellationToken cancellationToken = default);
    Task<NewsletterResponse> GetNewsletterAsync(int newsletterId, CancellationToken cancellationToken = default);
    Task DeleteNewsletterAsync(int newsletterId, CancellationToken cancellationToken = default);
    Task<NewsletterMetricsResponse> GetNewsletterMetricsAsync(int newsletterId, CancellationToken cancellationToken = default);
    Task<NewsletterMessagesResponse> GetNewsletterMessagesAsync(int newsletterId, string? next = null, CancellationToken cancellationToken = default);

    // Customers
    Task<CustomerAttributesResponse> GetCustomerAttributesAsync(string customerId, CancellationToken cancellationToken = default);
    Task<CustomerSegmentsResponse> GetCustomerSegmentsAsync(string customerId, CancellationToken cancellationToken = default);
    Task<CustomerMessagesResponse> GetCustomerMessagesAsync(string customerId, string? next = null, CancellationToken cancellationToken = default);
    Task<CustomerActivitiesResponse> GetCustomerActivitiesAsync(string customerId, string? next = null, CancellationToken cancellationToken = default);
    Task<CustomerSearchResponse> SearchCustomersAsync(CustomerSearchRequest request, string? next = null, CancellationToken cancellationToken = default);

    // Segments
    Task<SegmentResponse> CreateSegmentAsync(CreateSegmentRequest request, CancellationToken cancellationToken = default);
    Task<SegmentsResponse> ListSegmentsAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<SegmentResponse> GetSegmentAsync(int segmentId, CancellationToken cancellationToken = default);
    Task DeleteSegmentAsync(int segmentId, CancellationToken cancellationToken = default);
    Task<SegmentCustomerCountResponse> GetSegmentCustomerCountAsync(int segmentId, CancellationToken cancellationToken = default);
    Task<SegmentMembershipResponse> GetSegmentMembershipAsync(int segmentId, string? next = null, CancellationToken cancellationToken = default);

    // Messages
    Task<MessagesResponse> ListMessagesAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<MessageDetailResponse> GetMessageAsync(string messageId, CancellationToken cancellationToken = default);

    // Exports
    Task<ExportsResponse> ListExportsAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<ExportDetailResponse> GetExportAsync(int exportId, CancellationToken cancellationToken = default);
    Task<ExportDownloadResponse> GetExportDownloadUrlAsync(int exportId, CancellationToken cancellationToken = default);
    Task<ExportDetailResponse> ExportCustomersAsync(ExportCustomersRequest request, CancellationToken cancellationToken = default);
    Task<ExportDetailResponse> ExportDeliveriesAsync(ExportDeliveriesRequest request, CancellationToken cancellationToken = default);

    // Snippets
    Task<SnippetsResponse> ListSnippetsAsync(CancellationToken cancellationToken = default);
    Task<SnippetDetail> CreateSnippetAsync(CreateSnippetRequest request, CancellationToken cancellationToken = default);
    Task<SnippetDetail> UpdateSnippetAsync(UpdateSnippetRequest request, CancellationToken cancellationToken = default);
    Task DeleteSnippetAsync(string snippetName, CancellationToken cancellationToken = default);

    // Collections
    Task<CollectionsResponse> ListCollectionsAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<CollectionDetailResponse> CreateCollectionAsync(CreateCollectionRequest request, CancellationToken cancellationToken = default);
    Task<CollectionDetailResponse> GetCollectionAsync(int collectionId, CancellationToken cancellationToken = default);
    Task DeleteCollectionAsync(int collectionId, CancellationToken cancellationToken = default);
    Task<CollectionDetailResponse> UpdateCollectionAsync(int collectionId, UpdateCollectionRequest request, CancellationToken cancellationToken = default);

    // Reporting Webhooks
    Task<ReportingWebhooksResponse> ListReportingWebhooksAsync(CancellationToken cancellationToken = default);
    Task<ReportingWebhookDetailResponse> CreateReportingWebhookAsync(CreateReportingWebhookRequest request, CancellationToken cancellationToken = default);
    Task<ReportingWebhookDetailResponse> GetReportingWebhookAsync(int webhookId, CancellationToken cancellationToken = default);
    Task<ReportingWebhookDetailResponse> UpdateReportingWebhookAsync(int webhookId, UpdateReportingWebhookRequest request, CancellationToken cancellationToken = default);
    Task DeleteReportingWebhookAsync(int webhookId, CancellationToken cancellationToken = default);

    // Sender Identities
    Task<SenderIdentitiesResponse> ListSenderIdentitiesAsync(string? next = null, CancellationToken cancellationToken = default);
    Task<SenderIdentityDetailResponse> GetSenderIdentityAsync(int senderId, CancellationToken cancellationToken = default);
}

public class CustomerIOAppApiClient : ICustomerIOAppApiClient
{
    private readonly AppApiOptions _options;
    private readonly HttpClient _client;

    public CustomerIOAppApiClient(string apiKey)
        : this(new AppApiOptions { ApiKey = apiKey, Host = AppApiHosts.US })
    { }

    public CustomerIOAppApiClient(AppApiOptions options)
    {
        _options = options;
        _client = new HttpClient
        {
            BaseAddress = new Uri(options.Host ?? AppApiHosts.US)
        };
    }

    // -- Send Messages --------------------------------------------------------

    /// <summary>
    /// Send a transactional email to a customer. Use a template or provide <c>body</c>,
    /// <c>subject</c>, and <c>from</c> inline�inline values override the template.
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

    // -- Campaigns ------------------------------------------------------------

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

    // -- API-triggered Broadcasts ---------------------------------------------

    /// <summary>
    /// List all API-triggered broadcasts in the workspace.
    /// </summary>
    public async Task<BroadcastsResponse> ListBroadcastsAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/broadcasts";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific API-triggered broadcast.
    /// </summary>
    public async Task<BroadcastResponse> GetBroadcastAsync(int broadcastId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/broadcasts/{broadcastId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get aggregate delivery metrics for an API-triggered broadcast.
    /// </summary>
    public async Task<BroadcastMetricsResponse> GetBroadcastMetricsAsync(int broadcastId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/broadcasts/{broadcastId}/metrics");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastMetricsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the message deliveries sent by an API-triggered broadcast.
    /// </summary>
    public async Task<BroadcastMessagesResponse> GetBroadcastMessagesAsync(int broadcastId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/broadcasts/{broadcastId}/messages";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastMessagesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// List all triggers that have been fired for a broadcast.
    /// </summary>
    public async Task<BroadcastTriggersResponse> ListBroadcastTriggersAsync(int broadcastId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/broadcasts/{broadcastId}/triggers";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastTriggersResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the status and details of a specific broadcast trigger.
    /// </summary>
    public async Task<BroadcastTriggerDetailResponse> GetBroadcastTriggerAsync(int broadcastId, int triggerId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/campaigns/{broadcastId}/triggers/{triggerId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastTriggerDetailResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get validation errors for a specific broadcast trigger.
    /// </summary>
    public async Task<BroadcastTriggerErrorsResponse> GetBroadcastTriggerErrorsAsync(int broadcastId, int triggerId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/campaigns/{broadcastId}/triggers/{triggerId}/errors");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<BroadcastTriggerErrorsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    // -- Transactional Messages ------------------------------------------------

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

    // -- Newsletters ------------------------------------------------------------

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

    // -- Customers -------------------------------------------------------------

    /// <summary>
    /// Get the attributes (profile data) for a specific customer.
    /// </summary>
    public async Task<CustomerAttributesResponse> GetCustomerAttributesAsync(string customerId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/customers/{Uri.EscapeDataString(customerId)}/attributes");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CustomerAttributesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the segments a specific customer belongs to.
    /// </summary>
    public async Task<CustomerSegmentsResponse> GetCustomerSegmentsAsync(string customerId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/customers/{Uri.EscapeDataString(customerId)}/segments");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CustomerSegmentsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the message delivery history for a specific customer.
    /// </summary>
    public async Task<CustomerMessagesResponse> GetCustomerMessagesAsync(string customerId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/customers/{Uri.EscapeDataString(customerId)}/messages";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CustomerMessagesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the activity history (events, page views, emails, etc.) for a specific customer.
    /// </summary>
    public async Task<CustomerActivitiesResponse> GetCustomerActivitiesAsync(string customerId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/customers/{Uri.EscapeDataString(customerId)}/activities";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CustomerActivitiesResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Search for customers using a filter expression. Returns a page of customer IDs.
    /// </summary>
    public async Task<CustomerSearchResponse> SearchCustomersAsync(CustomerSearchRequest request, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/customers";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Post, url);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<CustomerSearchResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    // -- Segments --------------------------------------------------------------

    /// <summary>
    /// Create a new manual segment.
    /// </summary>
    public async Task<SegmentResponse> CreateSegmentAsync(CreateSegmentRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/segments");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// List all segments in the workspace.
    /// </summary>
    public async Task<SegmentsResponse> ListSegmentsAsync(string? next = null, CancellationToken cancellationToken = default)
    {
        var url = "/v1/segments";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentsResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the details of a specific segment.
    /// </summary>
    public async Task<SegmentResponse> GetSegmentAsync(int segmentId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/segments/{segmentId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Delete a manual segment.
    /// </summary>
    public async Task DeleteSegmentAsync(int segmentId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Delete, $"/v1/segments/{segmentId}");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Get the number of customers in a segment.
    /// </summary>
    public async Task<SegmentCustomerCountResponse> GetSegmentCustomerCountAsync(int segmentId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Get, $"/v1/segments/{segmentId}/customer_count");
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentCustomerCountResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Get the IDs of customers who are members of a segment.
    /// </summary>
    public async Task<SegmentMembershipResponse> GetSegmentMembershipAsync(int segmentId, string? next = null, CancellationToken cancellationToken = default)
    {
        var url = $"/v1/segments/{segmentId}/membership";
        if (!string.IsNullOrEmpty(next))
            url += $"?next={Uri.EscapeDataString(next)}";

        var req = BuildBaseRequest(HttpMethod.Get, url);
        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<SegmentMembershipResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    // -- Messages --------------------------------------------------------------

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

    // -- Exports ---------------------------------------------------------------

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

    // -- Snippets --------------------------------------------------------------

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

    // -- Collections -----------------------------------------------------------

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

    // -- Reporting Webhooks ----------------------------------------------------

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

    // -- Sender Identities -----------------------------------------------------

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

    // -- Private ---------------------------------------------------------------

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint)
    {
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", $"Bearer {_options.ApiKey}");
        return request;
    }
}

