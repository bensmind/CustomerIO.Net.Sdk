using CustomerIO.Net.Sdk.TrackApi.Models.AccountRegion;
using CustomerIO.Net.Sdk.TrackApi.Models.Customer;
using CustomerIO.Net.Sdk.TrackApi.Models.Event;
using CustomerIO.Net.Sdk.TrackApi.Models.Form;
using CustomerIO.Net.Sdk.TrackApi.Models.Segment;
using System.Net.Http.Json;

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

public class CustomerIOTrackApiClient : ICustomerIOTrackApiClient
{
    private readonly TrackApiOptions _options;
    private readonly HttpClient _client;

    public CustomerIOTrackApiClient(string apiKey)
        : this(new TrackApiOptions { ApiKey = apiKey, Host = TrackApiHosts.US })
    { }

    public CustomerIOTrackApiClient(TrackApiOptions options)
    {
        _options = options;
        _client = new HttpClient
        {
            BaseAddress = new Uri(options.Host ?? TrackApiHosts.US)
        };
    }

    /// <summary>
    /// Get the account region for the provided API key. This is useful for customers who have accounts in the EU region and need to confirm they are sending data to the correct endpoint.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The account region information.</returns>
    public async Task<AccountRegionResponse> GetAccountRegionAsync(CancellationToken cancellationToken = default)
    {
        var request = BuildBaseRequest(HttpMethod.Get, "/v1/account/region");

        var response = await _client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<AccountRegionResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    /// <summary>
    /// Add or update a customer (person) in Customer.io. If no person exists with the identifier,
    /// a new person is created.
    /// </summary>
    public async Task IdentifyCustomerAsync(string identifier, IdentifyCustomerRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Put, $"/api/v1/customers/{Uri.EscapeDataString(identifier)}");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Delete a customer and all of their information from Customer.io.
    /// </summary>
    public async Task DeleteCustomerAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Delete, $"/api/v1/customers/{Uri.EscapeDataString(identifier)}");

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Add or update a device for a customer. Customers can have more than one device.
    /// </summary>
    public async Task AddOrUpdateDeviceAsync(string identifier, AddDeviceRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Put, $"/api/v1/customers/{Uri.EscapeDataString(identifier)}/devices");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Remove a device from a customer profile.
    /// </summary>
    public async Task DeleteDeviceAsync(string identifier, string deviceId, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Delete, $"/api/v1/customers/{Uri.EscapeDataString(identifier)}/devices/{Uri.EscapeDataString(deviceId)}");

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Suppress a customer profile, deleting it and preventing the identifier from being re-added.
    /// </summary>
    public async Task SuppressCustomerAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/api/v1/customers/{Uri.EscapeDataString(identifier)}/suppress");

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Unsuppress a customer profile, making the identifier available to be re-added.
    /// </summary>
    public async Task UnsuppressCustomerAsync(string identifier, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/api/v1/customers/{Uri.EscapeDataString(identifier)}/unsuppress");

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Handle a custom unsubscribe request associated with a specific delivery.
    /// This endpoint does not require authentication.
    /// </summary>
    public async Task UnsubscribeAsync(string deliveryId, UnsubscribeRequest request, CancellationToken cancellationToken = default)
    {
        var req = new HttpRequestMessage(HttpMethod.Post, $"/unsubscribe/{Uri.EscapeDataString(deliveryId)}");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Merge two customer profiles. The secondary profile is deleted and its data is merged into the primary.
    /// This operation is not reversible.
    /// </summary>
    public async Task MergeCustomersAsync(MergeCustomersRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/api/v1/merge_customers");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Track an event associated with a specific customer.
    /// </summary>
    public async Task TrackEventAsync(string identifier, TrackEventRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/api/v1/customers/{Uri.EscapeDataString(identifier)}/events");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Track an anonymous event not yet associated with a known customer. If event merging is enabled
    /// and the anonymous_id matches a person's attribute, the event is associated with that person.
    /// </summary>
    public async Task TrackAnonymousEventAsync(TrackAnonymousEventRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/api/v1/events");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Report a delivery metric back to Customer.io for channels that don't natively report metrics
    /// (e.g. push, in-app). This endpoint does not require authentication.
    /// </summary>
    public async Task ReportMetricsAsync(MetricsRequest request, CancellationToken cancellationToken = default)
    {
        var req = new HttpRequestMessage(HttpMethod.Post, "/api/v1/metrics");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Report a push delivery metric back to Customer.io.
    /// </summary>
    [Obsolete("Use ReportMetricsAsync instead.")]
    public async Task ReportPushMetricsAsync(PushMetricsRequest request, CancellationToken cancellationToken = default)
    {
        var req = new HttpRequestMessage(HttpMethod.Post, "/api/v1/push/events");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Add people to a manual segment by their identifiers. Limited to 1000 per request.
    /// The segment must already exist.
    /// </summary>
    /// <param name="segmentId">The ID of the segment.</param>
    /// <param name="request">The identifiers to add.</param>
    /// <param name="idType">The type of identifier in the ids array. Use <see cref="SegmentIdType"/> constants. Defaults to "id".</param>
    public async Task AddCustomersToSegmentAsync(int segmentId, SegmentMembersRequest request, string? idType = null, CancellationToken cancellationToken = default)
    {
        var url = $"/api/v1/segments/{segmentId}/add_customers";
        if (!string.IsNullOrEmpty(idType))
            url += $"?id_type={Uri.EscapeDataString(idType)}";

        var req = BuildBaseRequest(HttpMethod.Post, url);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Remove people from a manual segment by their identifiers. Limited to 1000 per request.
    /// </summary>
    /// <param name="segmentId">The ID of the segment.</param>
    /// <param name="request">The identifiers to remove.</param>
    /// <param name="idType">The type of identifier in the ids array. Use <see cref="SegmentIdType"/> constants. Defaults to "id".</param>
    public async Task RemoveCustomersFromSegmentAsync(int segmentId, SegmentMembersRequest request, string? idType = null, CancellationToken cancellationToken = default)
    {
        var url = $"/api/v1/segments/{segmentId}/remove_customers";
        if (!string.IsNullOrEmpty(idType))
            url += $"?id_type={Uri.EscapeDataString(idType)}";

        var req = BuildBaseRequest(HttpMethod.Post, url);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <summary>
    /// Submit a form response. Identifies or creates a person based on the email or id in the data.
    /// If Customer.io does not recognize the form_id, a new form connection is created automatically.
    /// </summary>
    public async Task SubmitFormAsync(string formId, FormSubmitRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/api/v1/forms/{Uri.EscapeDataString(formId)}/submit");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint)
    {
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_options.ApiKey}:"))}");
        return request;
    }
}