using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.ReportingWebhook;

public class ReportingWebhooksResponse
{
    [JsonPropertyName("reporting_webhooks")]
    public IEnumerable<ReportingWebhookDetail> ReportingWebhooks { get; set; } = [];
}

public class ReportingWebhookDetailResponse
{
    [JsonPropertyName("reporting_webhook")]
    public ReportingWebhookDetail ReportingWebhook { get; set; } = null!;
}

public class ReportingWebhookDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; } = null!;

    [JsonPropertyName("disabled")]
    public bool Disabled { get; set; }

    [JsonPropertyName("events")]
    public ReportingWebhookEvents Events { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; set; }
}

public class ReportingWebhookEvents
{
    [JsonPropertyName("sent")]
    public bool Sent { get; set; }

    [JsonPropertyName("delivered")]
    public bool Delivered { get; set; }

    [JsonPropertyName("opened")]
    public bool Opened { get; set; }

    [JsonPropertyName("clicked")]
    public bool Clicked { get; set; }

    [JsonPropertyName("bounced")]
    public bool Bounced { get; set; }

    [JsonPropertyName("unsubscribed")]
    public bool Unsubscribed { get; set; }

    [JsonPropertyName("spammed")]
    public bool Spammed { get; set; }

    [JsonPropertyName("failed")]
    public bool Failed { get; set; }

    [JsonPropertyName("attempted")]
    public bool Attempted { get; set; }

    [JsonPropertyName("dropped")]
    public bool Dropped { get; set; }
}

public class CreateReportingWebhookRequest
{
    [JsonPropertyName("endpoint")]
    public string Endpoint { get; set; } = null!;

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [JsonPropertyName("events")]
    public ReportingWebhookEvents? Events { get; set; }
}

public class UpdateReportingWebhookRequest
{
    [JsonPropertyName("endpoint")]
    public string? Endpoint { get; set; }

    [JsonPropertyName("disabled")]
    public bool? Disabled { get; set; }

    [JsonPropertyName("events")]
    public ReportingWebhookEvents? Events { get; set; }
}
