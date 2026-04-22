using CustomerIO.Net.Sdk.Shared;

namespace CustomerIO.Net.Sdk.TrackApi;

public partial class CustomerIOTrackApiClient : BaseApiClient<TrackApiOptions>, ICustomerIOTrackApiClient
{
    public CustomerIOTrackApiClient(string apiKey)
        : this(new TrackApiOptions { ApiKey = apiKey, Host = TrackApiHosts.US })
    { }

    public CustomerIOTrackApiClient(TrackApiOptions options)
        : base(options)
    { }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint)
        => BuildBasicAuthRequest(method, endpoint);
}
