using CustomerIO.Net.Sdk.AppApi.Models.Customer;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiCustomersTests
{
    [Fact]
    public async Task GetCustomerAttributesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { customer = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCustomerAttributesAsync("cust-abc");

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/customers/cust-abc/attributes", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task GetCustomerSegmentsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { segments = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCustomerSegmentsAsync("cust-abc");

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/customers/cust-abc/segments", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetCustomerMessagesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { messages = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCustomerMessagesAsync("cust-abc");

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Contains("/v1/customers/cust-abc/messages", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetCustomerActivitiesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { activities = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCustomerActivitiesAsync("cust-abc");

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Contains("/v1/customers/cust-abc/activities", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task SearchCustomersAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { customers = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new CustomerSearchRequest { Filter = new { } };

        await client.SearchCustomersAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Contains("/v1/customers", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
