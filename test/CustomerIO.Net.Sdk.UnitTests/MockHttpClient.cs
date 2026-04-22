using Moq;
using Moq.Protected;
using System.Net;
using System.Text;
using System.Text.Json;

namespace CustomerIO.Net.Sdk.UnitTests;

/// <summary>
/// A wrapper around <see cref="Mock{HttpMessageHandler}"/> that captures the last
/// <see cref="HttpRequestMessage"/> sent and returns a pre-configured response.
/// </summary>
internal sealed class MockHttpClient
{
    private HttpRequestMessage? _lastRequest;
    private readonly Mock<HttpMessageHandler> _handlerMock;

    public HttpClient HttpClient { get; }
    public HttpRequestMessage? LastRequest => _lastRequest;

    public MockHttpClient(
        HttpStatusCode statusCode = HttpStatusCode.OK,
        string responseBody = "{}")
    {
        _handlerMock = new Mock<HttpMessageHandler>();

        _handlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .Callback<HttpRequestMessage, CancellationToken>((req, _) => _lastRequest = req)
            .ReturnsAsync(new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(responseBody, Encoding.UTF8, "application/json")
            });

        HttpClient = new HttpClient(_handlerMock.Object);
    }

    /// <summary>
    /// Creates a <see cref="MockHttpClient"/> whose response body is <paramref name="obj"/>
    /// serialized as JSON.
    /// </summary>
    public static MockHttpClient WithJson(object obj, HttpStatusCode statusCode = HttpStatusCode.OK)
        => new(statusCode, JsonSerializer.Serialize(obj));
}
