using CustomerIO.Net.Sdk.AppApi.Models.Newsletter;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiNewslettersTests
{
    [Fact]
    public async Task ListNewslettersAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { newsletters = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListNewslettersAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/newsletters", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListNewslettersAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListNewslettersAsync(next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task CreateNewsletterAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { newsletter = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new CreateNewsletterRequest { Name = "My Newsletter" };

        await client.CreateNewsletterAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/newsletters", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetNewsletterAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { newsletter = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetNewsletterAsync(7);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/newsletters/7", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task DeleteNewsletterAsync_SendsDeleteRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.DeleteNewsletterAsync(7);

        Assert.Equal(HttpMethod.Delete, mock.LastRequest!.Method);
        Assert.Equal("/v1/newsletters/7", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetNewsletterMetricsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { metric = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetNewsletterMetricsAsync(7);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/newsletters/7/metrics", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetNewsletterMessagesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { messages = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetNewsletterMessagesAsync(7);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Contains("/v1/newsletters/7", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
