namespace CustomerIO.Net.Sdk.PipelinesApi;

public partial class CustomerIOPipelinesApiClient : ICustomerIOPipelinesApiClient
{
    private readonly PipelinesApiOptions _options;
    private readonly HttpClient _client;

    public CustomerIOPipelinesApiClient(string apiKey)
        : this(new PipelinesApiOptions { ApiKey = apiKey, Host = PipelinesApiHosts.US })
    { }

    public CustomerIOPipelinesApiClient(PipelinesApiOptions options)
    {
        _options = options;
        _client = new HttpClient
        {
            BaseAddress = new Uri(options.Host ?? PipelinesApiHosts.US)
        };
    }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint, bool strictMode = false)
    {
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_options.ApiKey}:"))}");

        if (strictMode)
        {
            request.Headers.Add("X-Strict-Mode", "1");
        }

        return request;
    }
}
