namespace CustomerIO.Net.Sdk.Shared;

public class CustomerIORateLimitException(string message) : Exception(message)
{
}