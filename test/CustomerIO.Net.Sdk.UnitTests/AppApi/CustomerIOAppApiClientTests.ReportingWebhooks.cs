using CustomerIO.Net.Sdk.AppApi.Models.ReportingWebhook;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiReportingWebhooksTests
{
    [Fact]
    public async Task ListReportingWebhooksAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { reporting_webhooks = Array.Empty<object>() });
        var client = ClientFactory.CreateAppClient(mock);

        await client.ListReportingWebhooksAsync();

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/reporting_webhooks", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task CreateReportingWebhookAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { reporting_webhook = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new CreateReportingWebhookRequest { Endpoint = "https://example.com/hook" };

        await client.CreateReportingWebhookAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/reporting_webhooks", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task GetReportingWebhookAsync_SendsGetRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { reporting_webhook = new { } });
        var client = ClientFactory.CreateAppClient(mock);

        await client.GetReportingWebhookAsync(3);

        Assert.Equal(HttpMethod.Get, mock.LastRequest!.Method);
        Assert.Equal("/v1/reporting_webhooks/3", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task UpdateReportingWebhookAsync_SendsPutRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { reporting_webhook = new { } });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new UpdateReportingWebhookRequest { Endpoint = "https://example.com/hook2" };

        await client.UpdateReportingWebhookAsync(3, request);

        Assert.Equal(HttpMethod.Put, mock.LastRequest!.Method);
        Assert.Equal("/v1/reporting_webhooks/3", mock.LastRequest.RequestUri!.PathAndQuery);
    }

    [Fact]
    public async Task DeleteReportingWebhookAsync_SendsDeleteRequest_ToCorrectEndpoint()
    {
        var (client, mock) = ClientFactory.CreateAppClient();

        await client.DeleteReportingWebhookAsync(3);

        Assert.Equal(HttpMethod.Delete, mock.LastRequest!.Method);
        Assert.Equal("/v1/reporting_webhooks/3", mock.LastRequest.RequestUri!.PathAndQuery);
    }
}
