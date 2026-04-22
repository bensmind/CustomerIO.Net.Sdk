using CustomerIO.Net.Sdk.PipelinesApi.Models;

namespace CustomerIO.Net.Sdk.UnitTests.PipelinesApi;

public class PipelinesApiCallsTests
{
    // --- IdentifyAsync ---

    [Fact]
    public async Task IdentifyAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.IdentifyAsync(new IdentifyRequest { UserId = "u-1" });

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/identify", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task IdentifyAsync_WithStrictMode_AddsStrictModeHeader()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.IdentifyAsync(new IdentifyRequest(), strictMode: true);

        Assert.Equal("1", mock.LastRequest!.Headers.GetValues("X-Strict-Mode").First());
    }

    [Fact]
    public async Task IdentifyAsync_WithoutStrictMode_DoesNotAddStrictModeHeader()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.IdentifyAsync(new IdentifyRequest());

        Assert.False(mock.LastRequest!.Headers.Contains("X-Strict-Mode"));
    }

    // --- TrackAsync ---

    [Fact]
    public async Task TrackAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.TrackAsync(new TrackRequest { Event = "purchase" });

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/track", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task TrackAsync_WithStrictMode_AddsStrictModeHeader()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.TrackAsync(new TrackRequest { Event = "purchase" }, strictMode: true);

        Assert.Equal("1", mock.LastRequest!.Headers.GetValues("X-Strict-Mode").First());
    }

    // --- PageAsync ---

    [Fact]
    public async Task PageAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.PageAsync(new PageRequest());

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/page", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    // --- ScreenAsync ---

    [Fact]
    public async Task ScreenAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.ScreenAsync(new ScreenRequest());

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/screen", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    // --- GroupAsync ---

    [Fact]
    public async Task GroupAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.GroupAsync(new GroupRequest { GroupId = "grp-1" });

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/group", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    // --- AliasAsync ---

    [Fact]
    public async Task AliasAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        await client.AliasAsync(new AliasRequest { UserId = "new-id", PreviousId = "old-id" });

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/alias", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    // --- BatchAsync ---

    [Fact]
    public async Task BatchAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        var request = new BatchRequest
        {
            Batch = [new TrackRequest { Event = "click" }]
        };

        await client.BatchAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/batch", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task BatchAsync_WithStrictMode_AddsStrictModeHeader()
    {
        var (client, mock) = ClientFactory.CreatePipelinesClient();
        var request = new BatchRequest { Batch = [] };

        await client.BatchAsync(request, strictMode: true);

        Assert.Equal("1", mock.LastRequest!.Headers.GetValues("X-Strict-Mode").First());
    }
}

