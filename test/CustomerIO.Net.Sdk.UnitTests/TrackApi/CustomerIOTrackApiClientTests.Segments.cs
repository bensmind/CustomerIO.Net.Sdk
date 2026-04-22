using CustomerIO.Net.Sdk.TrackApi.Models.Segment;

namespace CustomerIO.Net.Sdk.UnitTests.TrackApi;

public class TrackApiSegmentsTests
{
    [Fact]
    public async Task AddCustomersToSegmentAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new SegmentMembersRequest { Ids = ["cust-1", "cust-2"] };

        await client.AddCustomersToSegmentAsync(42, request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/segments/42/add_customers", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task AddCustomersToSegmentAsync_AppendsIdType_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new SegmentMembersRequest { Ids = ["test@example.com"] };

        await client.AddCustomersToSegmentAsync(42, request, SegmentIdType.Email);

        Assert.Equal("/api/v1/segments/42/add_customers?id_type=email", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task RemoveCustomersFromSegmentAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new SegmentMembersRequest { Ids = ["cust-1"] };

        await client.RemoveCustomersFromSegmentAsync(42, request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/segments/42/remove_customers", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task RemoveCustomersFromSegmentAsync_AppendsIdType_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new SegmentMembersRequest { Ids = ["cio-123"] };

        await client.RemoveCustomersFromSegmentAsync(42, request, SegmentIdType.CioId);

        Assert.Equal("/api/v1/segments/42/remove_customers?id_type=cio_id", mock.LastRequest!.RequestUri!.PathAndQuery);
    }
}
