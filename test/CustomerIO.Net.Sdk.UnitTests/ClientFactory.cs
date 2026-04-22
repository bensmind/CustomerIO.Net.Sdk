using CustomerIO.Net.Sdk.AppApi;
using CustomerIO.Net.Sdk.PipelinesApi;
using CustomerIO.Net.Sdk.TrackApi;

namespace CustomerIO.Net.Sdk.UnitTests;

/// <summary>
/// Helper methods for creating API clients wired to a <see cref="MockHttpClient"/>.
/// </summary>
internal static class ClientFactory
{
    // --- TrackApi ---

    public static CustomerIOTrackApiClient CreateTrackClient(MockHttpClient mock)
    {
        mock.HttpClient.BaseAddress = new Uri(TrackApiHosts.US);
        return new CustomerIOTrackApiClient(
            new TrackApiOptions { ApiKey = TestConstants.TestApiKey },
            mock.HttpClient);
    }

    public static (CustomerIOTrackApiClient client, MockHttpClient mock) CreateTrackClient()
    {
        var mock = new MockHttpClient();
        return (CreateTrackClient(mock), mock);
    }

    // --- AppApi ---

    public static CustomerIOAppApiClient CreateAppClient(MockHttpClient mock)
    {
        mock.HttpClient.BaseAddress = new Uri(AppApiHosts.US);
        return new CustomerIOAppApiClient(
            new AppApiOptions { ApiKey = TestConstants.TestApiKey },
            mock.HttpClient);
    }

    public static (CustomerIOAppApiClient client, MockHttpClient mock) CreateAppClient()
    {
        var mock = new MockHttpClient();
        return (CreateAppClient(mock), mock);
    }

    // --- PipelinesApi ---

    public static CustomerIOPipelinesApiClient CreatePipelinesClient(MockHttpClient mock)
    {
        mock.HttpClient.BaseAddress = new Uri(PipelinesApiHosts.US);
        return new CustomerIOPipelinesApiClient(
            new PipelinesApiOptions { ApiKey = TestConstants.TestApiKey },
            mock.HttpClient);
    }

    public static (CustomerIOPipelinesApiClient client, MockHttpClient mock) CreatePipelinesClient()
    {
        var mock = new MockHttpClient();
        return (CreatePipelinesClient(mock), mock);
    }
}
