namespace CustomerIO.Net.Sdk.TrackApi;

public partial class CustomerIOTrackApiClient : ICustomerIOTrackApiClient
{
    private readonly TrackApiOptions _options;
    private readonly HttpClient _client;

    public CustomerIOTrackApiClient(string apiKey)
        : this(new TrackApiOptions { ApiKey = apiKey, Host = TrackApiHosts.US })
    { }

    public CustomerIOTrackApiClient(TrackApiOptions options)
    {
        _options = options;
        _client = new HttpClient
        {
            BaseAddress = new Uri(options.Host ?? TrackApiHosts.US)
        };
    }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint)
    {
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_options.ApiKey}:"))}");
        return request;
    }
}
