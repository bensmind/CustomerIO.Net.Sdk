namespace CustomerIO.Net.Sdk.AppApi;

public partial class CustomerIOAppApiClient : ICustomerIOAppApiClient
{
    private readonly AppApiOptions _options;
    private readonly HttpClient _client;

    public CustomerIOAppApiClient(string apiKey)
        : this(new AppApiOptions { ApiKey = apiKey, Host = AppApiHosts.US })
    { }

    public CustomerIOAppApiClient(AppApiOptions options)
    {
        _options = options;
        _client = new HttpClient
        {
            BaseAddress = new Uri(options.Host ?? AppApiHosts.US)
        };
    }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint)
    {
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", $"Bearer {_options.ApiKey}");
        return request;
    }
}
