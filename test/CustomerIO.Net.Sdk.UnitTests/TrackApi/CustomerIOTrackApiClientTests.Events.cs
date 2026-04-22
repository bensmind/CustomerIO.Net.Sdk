using CustomerIO.Net.Sdk.TrackApi.Models.Event;

namespace CustomerIO.Net.Sdk.UnitTests.TrackApi;

public class TrackApiEventsTests
{
    [Fact]
    public async Task TrackEventAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new TrackEventRequest { Name = "purchase" };

        await client.TrackEventAsync("cust-123", request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/customers/cust-123/events", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task TrackAnonymousEventAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new TrackAnonymousEventRequest { Name = "page_viewed" };

        await client.TrackAnonymousEventAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/events", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ReportMetricsAsync_SendsPostRequest_WithNoAuthHeader()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new MetricsRequest();

        await client.ReportMetricsAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/metrics", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Null(mock.LastRequest.Headers.Authorization);
    }

    [Fact]
    public async Task ReportPushMetricsAsync_SendsPostRequest_WithNoAuthHeader()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
#pragma warning disable CS0618
        var request = new PushMetricsRequest();
        await client.ReportPushMetricsAsync(request);
#pragma warning restore CS0618

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/push/events", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Null(mock.LastRequest.Headers.Authorization);
    }
}
