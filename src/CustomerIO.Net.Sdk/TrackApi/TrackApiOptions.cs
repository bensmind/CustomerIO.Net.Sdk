using CustomerIO.Net.Sdk.Shared;

namespace CustomerIO.Net.Sdk.TrackApi;

public class TrackApiOptions : BaseApiOptions
{
    public override required string Host { get; set; } = TrackApiHosts.US;
}

public class TrackApiHosts
{
    public const string US = "https://track.customer.io";
    public const string EU = "https://track-eu.customer.io";

}