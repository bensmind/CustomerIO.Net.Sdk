using CustomerIO.Net.Sdk.AppApi.Models.Export;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiExportsTests
{
    [Fact]
    public async Task ListExportsAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { exports = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListExportsAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/exports", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ListExportsAsync_AppendsNextToken_WhenProvided()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.ListExportsAsync(next: "tok");

        Assert.Contains("?next=tok", mock.LastRequest!.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetExportAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { export = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetExportAsync(1);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/exports/1", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetExportDownloadUrlAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { url = "https://example.com/file.csv" });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetExportDownloadUrlAsync(1);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/exports/1/download", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task ExportCustomersAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { export = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new ExportCustomersRequest();

        await client.ExportCustomersAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/exports/customers", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task ExportDeliveriesAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { export = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new ExportDeliveriesRequest();

        await client.ExportDeliveriesAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/exports/deliveries", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
