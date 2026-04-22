using CustomerIO.Net.Sdk.PipelinesApi.Models;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.PipelinesApi;

public interface ICustomerIOPipelinesApiClient
{
    /// <summary>
    /// Add or update a person and set traits on their profile.
    /// </summary>
    Task IdentifyAsync(IdentifyRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Record a named event that a person performed, along with optional properties.
    /// </summary>
    Task TrackAsync(TrackRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Record that a person viewed a page in a web application.
    /// </summary>
    Task PageAsync(PageRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Record that a person viewed a screen in a mobile application.
    /// </summary>
    Task ScreenAsync(ScreenRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Associate a person with a group/object and set traits on that object.
    /// </summary>
    Task GroupAsync(GroupRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Merge two profiles by mapping a previous identifier to a new (canonical) identifier.
    /// </summary>
    Task AliasAsync(AliasRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send multiple Pipelines API calls in a single HTTP request.
    /// Each item in the batch may be an <see cref="IdentifyRequest"/>, <see cref="TrackRequest"/>,
    /// <see cref="PageRequest"/>, <see cref="ScreenRequest"/>, or <see cref="GroupRequest"/>.
    /// </summary>
    Task BatchAsync(BatchRequest request, bool strictMode = false, CancellationToken cancellationToken = default);
}

public class CustomerIOPipelinesApiClient : ICustomerIOPipelinesApiClient
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

    /// <inheritdoc/>
    public async Task IdentifyAsync(IdentifyRequest request, bool strictMode = false, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/identify", strictMode);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task TrackAsync(TrackRequest request, bool strictMode = false, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/track", strictMode);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task PageAsync(PageRequest request, bool strictMode = false, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/page", strictMode);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task ScreenAsync(ScreenRequest request, bool strictMode = false, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/screen", strictMode);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task GroupAsync(GroupRequest request, bool strictMode = false, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/group", strictMode);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task AliasAsync(AliasRequest request, bool strictMode = false, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/alias", strictMode);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }

    /// <inheritdoc/>
    public async Task BatchAsync(BatchRequest request, bool strictMode = false, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, "/v1/batch", strictMode);
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
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