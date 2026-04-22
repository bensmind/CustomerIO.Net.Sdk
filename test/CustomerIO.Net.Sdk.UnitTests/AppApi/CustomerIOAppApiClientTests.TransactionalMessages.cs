using CustomerIO.Net.Sdk.AppApi.Models.TransactionalMessage;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiTransactionalMessagesTests
{
    [Fact]
    public async Task ListTransactionalMessagesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { messages = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListTransactionalMessagesAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/transactional", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListTransactionalMessagesAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListTransactionalMessagesAsync(next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetTransactionalMessageAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { message = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetTransactionalMessageAsync(3);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/transactional/3", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetTransactionalMessageMetricsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { metric = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetTransactionalMessageMetricsAsync(3);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/transactional/3/metrics", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetTransactionalMessageDeliveriesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { deliveries = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetTransactionalMessageDeliveriesAsync(3);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Contains("/v1/transactional/3", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
