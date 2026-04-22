using CustomerIO.Net.Sdk.TrackApi.Models.Form;

namespace CustomerIO.Net.Sdk.UnitTests.TrackApi;

public class TrackApiFormsTests
{
    [Fact]
    public async Task SubmitFormAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateTrackClient();
        var request = new FormSubmitRequest { Data = new Dictionary<string, string> { ["email"] = "user@example.com" } };

        await client.SubmitFormAsync("form-abc", request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/api/v1/forms/form-abc/submit", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BasicAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }
}
