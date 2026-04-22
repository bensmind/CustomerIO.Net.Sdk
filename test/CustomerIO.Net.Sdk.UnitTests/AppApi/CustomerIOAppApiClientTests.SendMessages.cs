using CustomerIO.Net.Sdk.AppApi.Models.Broadcast;
using CustomerIO.Net.Sdk.AppApi.Models.Newsletter;
using CustomerIO.Net.Sdk.AppApi.Models.Transactional;

namespace CustomerIO.Net.Sdk.UnitTests.AppApi;

public class AppApiSendMessagesTests
{
    [Fact]
    public async Task SendEmailAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { delivery_id = "d-123" });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new SendEmailRequest { To = "user@example.com", Identifiers = new TransactionalIdentifiers { Id = "cust-1" } };

        await client.SendEmailAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/send/email", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task SendPushAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { delivery_id = "d-123" });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new SendPushRequest { To = "user@example.com", Identifiers = new TransactionalIdentifiers { Id = "cust-1" } };

        await client.SendPushAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/send/push", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task SendSmsAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { delivery_id = "d-123" });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new SendSmsRequest { To = "+15555555555", Identifiers = new TransactionalIdentifiers { Id = "cust-1" } };

        await client.SendSmsAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/send/sms", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task SendInboxMessageAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { delivery_id = "d-123" });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new SendInboxMessageRequest { TransactionalMessageId = 1, Identifiers = new TransactionalIdentifiers { Id = "cust-1" } };

        await client.SendInboxMessageAsync(request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/send/inbox_message", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task TriggerBroadcastAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { delivery_id = "d-123" });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new TriggerBroadcastRequest();

        await client.TriggerBroadcastAsync(99, request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/campaigns/99/triggers", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task SendNewsletterAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { id = 1 });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new SendNewsletterRequest();

        await client.SendNewsletterAsync(7, request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/newsletters/7/send", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }

    [Fact]
    public async Task ScheduleNewsletterAsync_SendsPostRequest_ToCorrectEndpoint()
    {
        var mock = MockHttpClient.WithJson(new { id = 1 });
        var client = ClientFactory.CreateAppClient(mock);
        var request = new ScheduleNewsletterRequest { ScheduledAt = 1700000000 };

        await client.ScheduleNewsletterAsync(7, request);

        Assert.Equal(HttpMethod.Post, mock.LastRequest!.Method);
        Assert.Equal("/v1/newsletters/7/schedule", mock.LastRequest.RequestUri!.PathAndQuery);
        Assert.Equal(TestConstants.BearerAuthHeader, mock.LastRequest.Headers.Authorization?.ToString());
    }
}
