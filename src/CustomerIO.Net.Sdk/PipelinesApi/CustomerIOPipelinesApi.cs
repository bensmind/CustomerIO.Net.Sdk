using CustomerIO.Net.Sdk.Shared;

namespace CustomerIO.Net.Sdk.PipelinesApi;

public partial class CustomerIOPipelinesApiClient : BaseApiClient<PipelinesApiOptions>, ICustomerIOPipelinesApiClient
{
    public CustomerIOPipelinesApiClient(string apiKey)
        : this(new PipelinesApiOptions { ApiKey = apiKey, Host = PipelinesApiHosts.US })
    { }

    public CustomerIOPipelinesApiClient(PipelinesApiOptions options)
        : base(options)
    { }

    internal CustomerIOPipelinesApiClient(PipelinesApiOptions options, HttpClient httpClient)
        : base(options, httpClient)
    { }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint, bool strictMode = false)
    {
        var req = BuildBasicAuthRequest(method, endpoint);
        if (strictMode)
            req.Headers.Add("X-Strict-Mode", "1");
        return req;
    }
}
