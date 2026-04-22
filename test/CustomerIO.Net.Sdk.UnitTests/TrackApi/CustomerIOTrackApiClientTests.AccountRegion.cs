using CustomerIO.Net.Sdk.TrackApi.Models.AccountRegion;

namespace CustomerIO.Net.Sdk.UnitTests.TrackApi;

public class TrackApiAccountRegionTests
{
    [Fact]
    public async Task GetAccountRegionAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { region = "us" });
        var client = ClientFactory.CreateTrackClient(mock);

        await client.GetAccountRegionAsync();

        Assert.NotNull(mock.LastRequest);
        Assert.Equal(HttpMethod.Get, mock.LastRequest.Method);
        Assert.Equal("/v1/account/region", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetAccountRegionAsync_IncludesBasicAuthHeader()
    {
        var mock = MockHttpClient.WithJson(new { region = "us" });
        var client = ClientFactory.CreateTrackClient(mock);

        await client.GetAccountRegionAsync();

        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest!.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task GetAccountRegionAsync_ReturnsDeserializedResponse()
    {
        var mock = MockHttpClient.WithJson(new AccountRegionResponse());
        var client = ClientFactory.CreateTrackClient(mock);

        var result = await client.GetAccountRegionAsync();

        Assert.NotNull(result);
    }
}
