namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiMessagesTests
{
    [Fact]
    public async Task ListMessagesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { messages = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListMessagesAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/messages", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListMessagesAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListMessagesAsync(next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetMessageAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { message = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetMessageAsync("msg-abc");

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/messages/msg-abc", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
