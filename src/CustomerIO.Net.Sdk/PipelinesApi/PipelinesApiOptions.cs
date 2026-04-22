using CustomerIO.Net.Sdk.Shared;

namespace CustomerIO.Net.Sdk.PipelinesApi;

public class PipelinesApiOptions : BaseApiOptions
{
    public override string Host { get; set; } = PipelinesApiHosts.US;
}

public static class PipelinesApiHosts
{
    public const string US = "https://cdp.customer.io";
    public const string EU = "https://cdp-eu.customer.io";
}
