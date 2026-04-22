using CustomerIO.Net.Sdk.AppApi.Models.Customer;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient
{
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
}
