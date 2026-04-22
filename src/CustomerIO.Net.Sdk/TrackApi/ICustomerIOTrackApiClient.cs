using CustomerIO.Net.Sdk.TrackApi.Models.AccountRegion;
using CustomerIO.Net.Sdk.TrackApi.Models.Customer;
using CustomerIO.Net.Sdk.TrackApi.Models.Event;
using CustomerIO.Net.Sdk.TrackApi.Models.Form;
using CustomerIO.Net.Sdk.TrackApi.Models.Segment;

namespace CustomerIO.Net.Sdk.TrackApi;

public interface ICustomerIOTrackApiClient
{
    // Account Region
    Task<AccountRegionResponse> GetAccountRegionAsync(CancellationToken cancellationToken = default);

    // Customers
    Task IdentifyCustomerAsync(string identifier, IdentifyCustomerRequest request, CancellationToken cancellationToken = default);
    Task DeleteCustomerAsync(string identifier, CancellationToken cancellationToken = default);
    Task AddOrUpdateDeviceAsync(string identifier, AddDeviceRequest request, CancellationToken cancellationToken = default);
    Task DeleteDeviceAsync(string identifier, string deviceId, CancellationToken cancellationToken = default);
    Task SuppressCustomerAsync(string identifier, CancellationToken cancellationToken = default);
    Task UnsuppressCustomerAsync(string identifier, CancellationToken cancellationToken = default);
    Task UnsubscribeAsync(string deliveryId, UnsubscribeRequest request, CancellationToken cancellationToken = default);
    Task MergeCustomersAsync(MergeCustomersRequest request, CancellationToken cancellationToken = default);

    // Events
    Task TrackEventAsync(string identifier, TrackEventRequest request, CancellationToken cancellationToken = default);
    Task TrackAnonymousEventAsync(TrackAnonymousEventRequest request, CancellationToken cancellationToken = default);
    Task ReportMetricsAsync(MetricsRequest request, CancellationToken cancellationToken = default);
    [Obsolete("Use ReportMetricsAsync instead.")]
    Task ReportPushMetricsAsync(PushMetricsRequest request, CancellationToken cancellationToken = default);

    // Segments
    Task AddCustomersToSegmentAsync(int segmentId, SegmentMembersRequest request, string? idType = null, CancellationToken cancellationToken = default);
    Task RemoveCustomersFromSegmentAsync(int segmentId, SegmentMembersRequest request, string? idType = null, CancellationToken cancellationToken = default);

    // Forms
    Task SubmitFormAsync(string formId, FormSubmitRequest request, CancellationToken cancellationToken = default);
}
