using CustomerIO.Net.Sdk.AppApi.Models.Campaign;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiCampaignsTests
{
    [Fact]
    public async Task ListCampaignsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { campaigns = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListCampaignsAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListCampaignsAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListCampaignsAsync(next: "page-token");

        Assert.Equal("/v1/campaigns?next=page-token", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetCampaignAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { campaign = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCampaignAsync(55);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/55", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task GetCampaignMetricsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { metric = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCampaignMetricsAsync(55);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/55/metrics", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetCampaignMessagesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { messages = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCampaignMessagesAsync(55);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/55/messages", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetCampaignMessagesAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.GetCampaignMessagesAsync(55, next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task ListCampaignActionsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { actions = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListCampaignActionsAsync(55);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/55/actions", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetCampaignActionAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { action = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCampaignActionAsync(55, "action-xyz");

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/55/actions/action-xyz", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task UpdateCampaignActionAsync_SendsPutRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { action = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new UpdateCampaignActionRequest();

        await client.UpdateCampaignActionAsync(55, "action-xyz", request);

        Assert.Equal(HttpMethod.Put, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/55/actions/action-xyz", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
