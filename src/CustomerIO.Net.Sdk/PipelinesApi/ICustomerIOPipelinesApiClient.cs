using CustomerIO.Net.Sdk.PipelinesApi.Models;

namespace CustomerIO.Net.Sdk.PipelinesApi;

public interface ICustomerIOPipelinesApiClient
{
    /// <summary>
    /// Add or update a person and set traits on their profile.
    /// </summary>
    Task IdentifyAsync(IdentifyRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Record a named event that a person performed, along with optional properties.
    /// </summary>
    Task TrackAsync(TrackRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Record that a person viewed a page in a web application.
    /// </summary>
    Task PageAsync(PageRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Record that a person viewed a screen in a mobile application.
    /// </summary>
    Task ScreenAsync(ScreenRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Associate a person with a group/object and set traits on that object.
    /// </summary>
    Task GroupAsync(GroupRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Merge two profiles by mapping a previous identifier to a new (canonical) identifier.
    /// </summary>
    Task AliasAsync(AliasRequest request, bool strictMode = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Send multiple Pipelines API calls in a single HTTP request.
    /// Each item in the batch may be an <see cref="IdentifyRequest"/>, <see cref="TrackRequest"/>,
    /// <see cref="PageRequest"/>, <see cref="ScreenRequest"/>, or <see cref="GroupRequest"/>.
    /// </summary>
    Task BatchAsync(BatchRequest request, bool strictMode = false, CancellationToken cancellationToken = default);
}
