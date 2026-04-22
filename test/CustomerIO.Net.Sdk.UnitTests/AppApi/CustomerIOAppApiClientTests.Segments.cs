using CustomerIO.Net.Sdk.AppApi.Models.Segment;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiSegmentsTests
{
    [Fact]
    public async Task CreateSegmentAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { segment = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new CreateSegmentRequest { Name = "VIP" };

        await client.CreateSegmentAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/segments", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListSegmentsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { segments = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListSegmentsAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/segments", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task ListSegmentsAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListSegmentsAsync(next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetSegmentAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { segment = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetSegmentAsync(10);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/segments/10", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task DeleteSegmentAsync_SendsDeleteRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.DeleteSegmentAsync(10);

        Assert.Equal(HttpMethod.Delete, mock.LastRequest!.Method);
        Assert.Equal("/v1/segments/10", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetSegmentCustomerCountAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { count = 42 });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetSegmentCustomerCountAsync(10);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/segments/10/customer_count", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetSegmentMembershipAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { ids = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetSegmentMembershipAsync(10);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Contains("/v1/segments/10/membership", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
