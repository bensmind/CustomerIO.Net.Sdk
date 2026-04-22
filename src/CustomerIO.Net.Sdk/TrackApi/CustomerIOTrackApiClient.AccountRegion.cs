using CustomerIO.Net.Sdk.TrackApi.Models.AccountRegion;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.TrackApi;

public partial class CustomerIOTrackApiClient
{
    /// <summary>
    /// Get the account region for the provided API key. This is useful for customers who have accounts
    /// in the EU region and need to confirm they are sending data to the correct endpoint.
    /// </summary>
    public async Task<AccountRegionResponse> GetAccountRegionAsync(CancellationToken cancellationToken = default)
    {
        var request = BuildBaseRequest(HttpMethod.Get, "/v1/account/region");

        var response = await _client.SendAsync(request, cancellationToken);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadFromJsonAsync<AccountRegionResponse>(cancellationToken: cancellationToken);
        return content!;
    }
}
