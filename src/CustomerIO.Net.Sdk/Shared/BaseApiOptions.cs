namespace CustomerIO.Net.Sdk.Shared;

public abstract class BaseApiOptions
{
    public required string ApiKey { get; set; }

    public required abstract string? Host { get; set; }
}