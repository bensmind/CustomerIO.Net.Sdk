using CustomerIO.Net.Sdk.TrackApi.Models.AccountRegion;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.TrackApi;

public interface ICustomerIOTrackApiClient
{
    Task<AccountRegionResponse> GetAccountRegionAsync(CancellationToken cancellationToken = default);
}

public class CustomerIOTrackApiClient : ICustomerIOTrackApiClient
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

    /// <summary>
    /// Get the account region for the provided API key. This is useful for customers who have accounts in the EU region and need to confirm they are sending data to the correct endpoint.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    /// <returns>The account region information.</returns>
    public async Task<AccountRegionResponse> GetAccountRegionAsync(CancellationToken cancellationToken = default)
    {
        var request = BuildBaseRequest(HttpMethod.Get, "/v1/account/region");

        var response = await _client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<AccountRegionResponse>(cancellationToken: cancellationToken);
        return content!;
    }

    private HttpRequestMessage BuildBaseRequest(HttpMethod method, string endpoint)
    {
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes($"{_options.ApiKey}:"))}");
        return request;
    }
}