using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Export;

public class ExportsResponse
{
    [JsonPropertyName("exports")]
    public IEnumerable<ExportDetail> Exports { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class ExportDetailResponse
{
    [JsonPropertyName("export")]
    public ExportDetail Export { get; set; } = null!;
}

public class ExportDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>e.g. "customers", "deliveries"</summary>
    [JsonPropertyName("type")]
    public string Type { get; set; } = null!;

    /// <summary>e.g. "pending", "running", "done", "failed"</summary>
    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("info")]
    public string? Info { get; set; }

    [JsonPropertyName("start_time")]
    public long? StartTime { get; set; }

    [JsonPropertyName("end_time")]
    public long? EndTime { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; set; }
}

public class ExportDownloadResponse
{
    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
}

public class ExportCustomersRequest
{
    /// <summary>
    /// Filter expression for which customers to export.
    /// </summary>
    [JsonPropertyName("filter")]
    public object? Filter { get; set; }

    /// <summary>
    /// Unix timestamp — export only customers created after this time.
    /// </summary>
    [JsonPropertyName("start")]
    public long? Start { get; set; }

    /// <summary>
    /// Unix timestamp — export only customers created before this time.
    /// </summary>
    [JsonPropertyName("end")]
    public long? End { get; set; }

    /// <summary>
    /// Specific attribute names to include in the export.
    /// </summary>
    [JsonPropertyName("fields")]
    public IEnumerable<string>? Fields { get; set; }
}

public class ExportDeliveriesRequest
{
    /// <summary>
    /// Unix timestamp — export only deliveries created after this time.
    /// </summary>
    [JsonPropertyName("start")]
    public long? Start { get; set; }

    /// <summary>
    /// Unix timestamp — export only deliveries created before this time.
    /// </summary>
    [JsonPropertyName("end")]
    public long? End { get; set; }

    /// <summary>
    /// Filter by delivery metric, e.g. "delivered", "opened", "clicked", "bounced".
    /// </summary>
    [JsonPropertyName("metric")]
    public string? Metric { get; set; }

    /// <summary>
    /// Filter by delivery type, e.g. "email", "push", "sms".
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
