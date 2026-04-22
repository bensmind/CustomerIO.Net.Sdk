using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.SenderIdentity;

public class SenderIdentitiesResponse
{
    [JsonPropertyName("identities")]
    public IEnumerable<SenderIdentityDetail> Identities { get; set; } = [];

    [JsonPropertyName("next")]
    public string? Next { get; set; }
}

public class SenderIdentityDetailResponse
{
    [JsonPropertyName("identity")]
    public SenderIdentityDetail Identity { get; set; } = null!;
}

public class SenderIdentityDetail
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("from_name")]
    public string? FromName { get; set; }

    [JsonPropertyName("reply_to")]
    public string? ReplyTo { get; set; }

    [JsonPropertyName("from_email")]
    public string? FromEmail { get; set; }

    [JsonPropertyName("created_at")]
    public long CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; set; }
}
