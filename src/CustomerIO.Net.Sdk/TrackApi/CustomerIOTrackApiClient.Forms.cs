using CustomerIO.Net.Sdk.TrackApi.Models.Form;
using System.Net.Http.Json;

namespace CustomerIO.Net.Sdk.TrackApi;

public partial class CustomerIOTrackApiClient
{
    /// <summary>
    /// Submit a form response. Identifies or creates a person based on the email or id in the data.
    /// If Customer.io does not recognize the form_id, a new form connection is created automatically.
    /// </summary>
    public async Task SubmitFormAsync(string formId, FormSubmitRequest request, CancellationToken cancellationToken = default)
    {
        var req = BuildBaseRequest(HttpMethod.Post, $"/api/v1/forms/{Uri.EscapeDataString(formId)}/submit");
        req.Content = JsonContent.Create(request);

        var response = await _client.SendAsync(req, cancellationToken);
        response.EnsureSuccessStatusCode();
    }
}
