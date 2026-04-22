using CustomerIO.Net.Sdk.AppApi.Models.Broadcast;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiBroadcastsTests
{
    [Fact]
    public async Task ListBroadcastsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { broadcasts = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListBroadcastsAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/broadcasts", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListBroadcastsAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListBroadcastsAsync(next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetBroadcastAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { broadcast = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetBroadcastAsync(11);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/broadcasts/11", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetBroadcastMetricsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { metric = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetBroadcastMetricsAsync(11);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/broadcasts/11/metrics", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetBroadcastMessagesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { messages = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetBroadcastMessagesAsync(11);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/broadcasts/11/messages", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task ListBroadcastTriggersAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { triggers = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListBroadcastTriggersAsync(11);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Contains("/v1/broadcasts/11/triggers", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetBroadcastTriggerAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { trigger = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetBroadcastTriggerAsync(11, 5);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/11/triggers/5", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetBroadcastTriggerErrorsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { errors = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetBroadcastTriggerErrorsAsync(11, 5);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/11/triggers/5/errors", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
