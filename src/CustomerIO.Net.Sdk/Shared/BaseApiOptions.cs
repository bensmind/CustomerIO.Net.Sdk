namespace CustomerIO.Net.Sdk.Shared;

public abstract class BaseApiOptions
{
    public required string ApiKey { get; set; }

    public string? Host { get; set; }
}