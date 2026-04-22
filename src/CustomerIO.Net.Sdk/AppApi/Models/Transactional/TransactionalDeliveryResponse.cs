using System.Text.Json.Serialization;

namespace CustomerIO.Net.Sdk.AppApi.Models.Transactional;

public class TransactionalDeliveryResponse
{
    [JsonPropertyName("delivery_id")]
    public string DeliveryId { get; set; } = null!;

    [JsonPropertyName("queued_at")]
    public long QueuedAt { get; set; }
}
