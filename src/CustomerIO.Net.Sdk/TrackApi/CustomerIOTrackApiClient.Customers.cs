using CustomerIO.Net.Sdk.TrackApi.Models.Customer;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.TrackApi;

public partial class CustomerIOTrackApiClient
{
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
}
