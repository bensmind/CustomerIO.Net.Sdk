using CustomerIO.Net.Sdk.AppApi.Models.Collection;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiCollectionsTests
{
    [Fact]
    public async Task ListCollectionsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { collections = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListCollectionsAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/collections", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListCollectionsAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListCollectionsAsync(next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task CreateCollectionAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { collection = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new CreateCollectionRequest { Name = "My Collection" };

        await client.CreateCollectionAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/collections", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetCollectionAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { collection = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetCollectionAsync(20);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/collections/20", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task DeleteCollectionAsync_SendsDeleteRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.DeleteCollectionAsync(20);

        Assert.Equal(HttpMethod.Delete, mock.LastRequest!.Method);
        Assert.Equal("/v1/collections/20", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task UpdateCollectionAsync_SendsPutRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { collection = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new UpdateCollectionRequest { Name = "Updated" };

        await client.UpdateCollectionAsync(20, request);

        Assert.Equal(HttpMethod.Put, mock.LastRequest!.Method);
        Assert.Equal("/v1/collections/20", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
