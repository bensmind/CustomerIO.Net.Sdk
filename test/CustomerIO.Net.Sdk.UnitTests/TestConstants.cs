using System.Text;

namespace CustomerIO.Net.Sdk.UnitTests;

internal static class TestConstants
{
    public const string TestApiKey = "test-api-key";

    public static string BasicAuthHeader
        => $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{TestApiKey}:"))}";

    public static string BearerAuthHeader
        => $"Bearer {TestApiKey}";
}
