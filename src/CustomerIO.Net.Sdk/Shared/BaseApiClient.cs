using System.Text;

namespace CustomerIO.Net.Sdk.Shared;

/// <summary>
/// Base class for all Customer.io API clients. Manages the <see cref="HttpClient"/>
/// and provides helper methods for building authenticated requests.
/// </summary>
public abstract class BaseApiClient<TOptions> where TOptions : BaseApiOptions
{
    protected readonly TOptions _options;
    protected readonly HttpClient _client;

    protected BaseApiClient(TOptions options, string defaultHost)
    {
        _options = options;
        _client = new HttpClient
        {
            BaseAddress = new Uri(options.Host ?? defaultHost)
        };
    }

    /// <summary>
    /// Builds a request with HTTP Basic authentication using the API key.
    /// The key is encoded as <c>base64("{apiKey}:")</c> (no password).
    /// Used by the Track API and Pipelines API.
    /// </summary>
    protected HttpRequestMessage BuildBasicAuthRequest(HttpMethod method, string endpoint)
    {
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_options.ApiKey}:"))}");
        return request;
    }

    /// <summary>
    /// Builds a request with HTTP Bearer token authentication using the API key.
    /// Used by the App API.
    /// </summary>
    protected HttpRequestMessage BuildBearerAuthRequest(HttpMethod method, string endpoint)
    {
        var request = new HttpRequestMessage(method, endpoint);
        request.Headers.Add("Authorization", $"Bearer {_options.ApiKey}");
        return request;
    }
}
