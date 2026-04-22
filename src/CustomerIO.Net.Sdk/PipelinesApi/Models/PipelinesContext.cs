using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.PipelinesApi.Models;

/// <summary>
/// Context about the source call — device, location, library, page, etc.
/// Automatically collected by Customer.io source libraries; supply manually
/// when integrating directly with the REST API.
/// </summary>
public class PipelinesContext
{
    /// <summary>The user's IP address.</summary>
    [JsonPropertyName("ip")]
    public string? Ip { get; set; }

    /// <summary>The user agent string of the device making the request.</summary>
    [JsonPropertyName("userAgent")]
    public string? UserAgent { get; set; }

    /// <summary>The locale string for the current user, e.g. "en-US".</summary>
    [JsonPropertyName("locale")]
    public string? Locale { get; set; }

    /// <summary>Whether the user is active.</summary>
    [JsonPropertyName("active")]
    public bool? Active { get; set; }

    /// <summary>
    /// The channel the event originated from: "browser", "server", or "mobile".
    /// </summary>
    [JsonPropertyName("channel")]
    public string? Channel { get; set; }

    /// <summary>Information about the source library sending the event.</summary>
    [JsonPropertyName("library")]
    public PipelinesLibraryContext? Library { get; set; }

    /// <summary>
    /// Information about the current page (browser events).
    /// Automatically collected by the JavaScript source.
    /// </summary>
    [JsonPropertyName("page")]
    public PipelinesPageContext? Page { get; set; }

    /// <summary>
    /// UTM campaign parameters gathered from the URL or passed manually.
    /// </summary>
    [JsonPropertyName("campaign")]
    public PipelinesCampaignContext? Campaign { get; set; }

    /// <summary>
    /// Mobile app information (screen events).
    /// </summary>
    [JsonPropertyName("app")]
    public PipelinesAppContext? App { get; set; }

    /// <summary>
    /// Mobile device information (screen events).
    /// </summary>
    [JsonPropertyName("device")]
    public PipelinesDeviceContext? Device { get; set; }

    /// <summary>Any additional context properties not listed above.</summary>
    [JsonExtensionData]
    public Dictionary<string, JsonElement>? AdditionalProperties { get; set; }
}

public class PipelinesLibraryContext
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }
}

public class PipelinesPageContext
{
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    [JsonPropertyName("referrer")]
    public string? Referrer { get; set; }

    [JsonPropertyName("search")]
    public string? Search { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }
}

public class PipelinesCampaignContext
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("source")]
    public string? Source { get; set; }

    [JsonPropertyName("medium")]
    public string? Medium { get; set; }

    [JsonPropertyName("term")]
    public string? Term { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }
}

public class PipelinesAppContext
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("build")]
    public string? Build { get; set; }
}

public class PipelinesDeviceContext
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("manufacturer")]
    public string? Manufacturer { get; set; }

    [JsonPropertyName("model")]
    public string? Model { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("version")]
    public string? Version { get; set; }

    [JsonPropertyName("token")]
    public string? Token { get; set; }
}

/// <summary>
/// Channel constants for <see cref="PipelinesContext.Channel"/>.
/// </summary>
public static class PipelinesChannel
{
    public const string Browser = "browser";
    public const string Server = "server";
    public const string Mobile = "mobile";
}
