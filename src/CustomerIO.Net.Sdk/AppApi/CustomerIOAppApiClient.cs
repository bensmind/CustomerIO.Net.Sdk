using CustomerIO.Net.Sdk.Shared;

namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient : BaseApiClient<AppApiOptions>, ICustomerIOAppApiClient
{
    public CustomerIOAppApiClient(string apiKey)
        : this(new AppApiOptions { ApiKey = apiKey })
    { }

    public CustomerIOAppApiClient(AppApiOptions options)
        : base(options, AppApiHosts.US)
    { }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint)
        => BuildBearerAuthRequest(method, endpoint);
}
