using CustomerIO.Net.Sdk.AppApi.Models.Snippet;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiSnippetsTests
{
    [Fact]
    public async Task ListSnippetsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { snippets = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListSnippetsAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/snippets", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task CreateSnippetAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { snippet = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new CreateSnippetRequest { Name = "my-snippet", Value = "Hello" };

        await client.CreateSnippetAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/snippets", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task UpdateSnippetAsync_SendsPutRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { snippet = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new UpdateSnippetRequest { Name = "my-snippet", Value = "Hello!" };

        await client.UpdateSnippetAsync(request);

        Assert.Equal(HttpMethod.Put, mock.LastRequest!.Method);
        Assert.Equal("/v1/snippets", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task DeleteSnippetAsync_SendsDeleteRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.DeleteSnippetAsync("my-snippet");

        Assert.Equal(HttpMethod.Delete, mock.LastRequest!.Method);
        Assert.Equal("/v1/snippets/my-snippet", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
