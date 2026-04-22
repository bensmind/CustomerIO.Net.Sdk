using CustomerIO.Net.Sdk.Shared;

namespace CustomerIO.Net.Sdk.AppApi;

public class AppApiOptions : BaseApiOptions
{
    public override required string Host { get; set; } = AppApiHosts.US;
}

public class AppApiHosts
{
    public const string US = "https://api.customer.io";
    public const string EU = "https://api-eu.customer.io";
}
