using CustomerIO.Net.Sdk.Shared;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient : BaseApiClient<AppApiOptions>, ICustomerIOAppApiClient
{
    public CustomerIOAppApiClient(string apiKey)
        : this(new AppApiOptions { ApiKey = apiKey, Host = AppApiHosts.US })
    { }

    public CustomerIOAppApiClient(AppApiOptions options)
        : base(options)
    { }

    internal CustomerIOAppApiClient(AppApiOptions options, HttpClient httpClient)
        : base(options, httpClient)
    { }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint)
        => BuildBearerAuthRequest(method, endpoint);
}
