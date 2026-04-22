using CustomerIO.Net.Sdk.TrackApi.Models.Customer;

namespace CustomerIO.Net.Sdk.UnitTests.TrackApi;

public class TrackApiCustomersTests
{
    [Fact]
    public async Task IdentifyCustomerAsync_SendsPutRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new IdentifyCustomerRequest();

        await client.IdentifyCustomerAsync("cust-123", request);

        Assert.Equal(HttpMethod.Put, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/customers/cust-123", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task DeleteCustomerAsync_SendsDeleteRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();

        await client.DeleteCustomerAsync("cust-123");

        Assert.Equal(HttpMethod.Delete, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/customers/cust-123", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task AddOrUpdateDeviceAsync_SendsPutRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new AddDeviceRequest
        {
            Device = new DeviceRequest { Id = "token-abc", Platform = DevicePlatform.Ios }
        };

        await client.AddOrUpdateDeviceAsync("cust-123", request);

        Assert.Equal(HttpMethod.Put, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/customers/cust-123/devices", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task DeleteDeviceAsync_SendsDeleteRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();

        await client.DeleteDeviceAsync("cust-123", "device-token");

        Assert.Equal(HttpMethod.Delete, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/customers/cust-123/devices/device-token", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task SuppressCustomerAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();

        await client.SuppressCustomerAsync("cust-123");

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/customers/cust-123/suppress", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task UnsuppressCustomerAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();

        await client.UnsuppressCustomerAsync("cust-123");

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/customers/cust-123/unsuppress", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task UnsubscribeAsync_SendsPostRequest_WithNoAuthHeader()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new UnsubscribeRequest { Unsubscribe = true };

        await client.UnsubscribeAsync("delivery-abc", request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/unsubscribe/delivery-abc", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Null(mock.LastRequest.Headers.Authorization);
    }

    [Fact]
    public async Task MergeCustomersAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new MergeCustomersRequest
        {
            Primary = new CustomerIdentifier { Id = "primary-id" },
            Secondary = new CustomerIdentifier { Id = "secondary-id" }
        };

        await client.MergeCustomersAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/merge_customers", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }
}
