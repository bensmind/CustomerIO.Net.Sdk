using CustomerIO.Net.Sdk.AppApi.Models.SenderIdentity;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiSenderIdentitiesTests
{
    [Fact]
    public async Task ListSenderIdentitiesAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { identities = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListSenderIdentitiesAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/sender_identities", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListSenderIdentitiesAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListSenderIdentitiesAsync(next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetSenderIdentityAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { identity = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetSenderIdentityAsync(5);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/sender_identities/5", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
