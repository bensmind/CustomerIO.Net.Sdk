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
