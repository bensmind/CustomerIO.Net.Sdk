# CustomerIO.Net.Sdk

An unofficial .NET 10 SDK for the [Customer.io](https://customer.io) REST APIs.

## API Clients

### App API (`CustomerIOAppApiClient`)

Wraps the [App API](https://docs.customer.io/integrations/api/app/) — used to manage campaigns, broadcasts, transactional messages, newsletters, segments, customers, exports, snippets, collections, reporting webhooks, and sender identities. Authenticates with a Bearer token using your **App API key**.

```csharp
var client = new CustomerIOAppApiClient(new AppApiOptions
{
    ApiKey = "YOUR_APP_API_KEY",
    Host = AppApiHosts.US // or AppApiHosts.EU
});

// Send a transactional email
var result = await client.SendEmailAsync(new SendEmailRequest
{
    To = "jane@example.com",
    Identifiers = new TransactionalIdentifiers { Email = "jane@example.com" },
    TransactionalMessageId = "welcome-email",
    MessageData = new Dictionary<string, object?>
    {
        ["first_name"] = "Jane"
    }
});

// Search for customers
var customers = await client.SearchCustomersAsync(new CustomerSearchRequest
{
    Filter = new Dictionary<string, object?> { ["email"] = "jane@example.com" }
});
```

---

### Track API (`CustomerIOTrackApiClient`)

Wraps the [Track API](https://docs.customer.io/integrations/api/track/) — used to identify people, track events, manage devices, and interact with segments and forms. Authenticates with HTTP Basic auth using your **Site ID** as the API key.

```csharp
var client = new CustomerIOTrackApiClient(new TrackApiOptions
{
    ApiKey = "YOUR_TRACK_API_KEY",
    Host = TrackApiHosts.US // or TrackApiHosts.EU
});

await client.IdentifyCustomerAsync("user-123", new IdentifyCustomerRequest
{
    Attributes = new Dictionary<string, object?>
    {
        ["email"] = "jane@example.com",
        ["name"] = "Jane Smith",
        ["plan"] = "pro"
    }
});

await client.TrackEventAsync("user-123", new TrackEventRequest
{
    Name = "Order Placed",
    Attributes = new Dictionary<string, object?>
    {
        ["order_id"] = "ord-456",
        ["total"] = 99.99
    }
});
```

---

### Pipelines (CDP) API (`CustomerIOPipelinesApiClient`)

Wraps the [Data Pipelines API](https://docs.customer.io/integrations/api/cdp/) — used to stream identify, track, page, screen, group, alias, and batch calls into Customer.io's CDP. Authenticates with HTTP Basic auth using your **Pipelines API key**.

```csharp
var client = new CustomerIOPipelinesApiClient(new PipelinesApiOptions
{
    ApiKey = "YOUR_PIPELINES_API_KEY",
    Host = PipelinesApiHosts.US // or PipelinesApiHosts.EU
});

// Identify a person
await client.IdentifyAsync(new IdentifyRequest
{
    UserId = "user-123",
    Traits = new Dictionary<string, object?>
    {
        ["email"] = "jane@example.com",
        ["name"] = "Jane Smith"
    }
});

// Track an event
await client.TrackAsync(new TrackRequest
{
    UserId = "user-123",
    Event = "Signed Up",
    Properties = new Dictionary<string, object?>
    {
        ["plan"] = "pro"
    }
});

// Batch multiple calls in one request
await client.BatchAsync(new BatchRequest
{
    Batch =
    [
        new IdentifyRequest { UserId = "user-123", Traits = new() { ["email"] = "jane@example.com" } },
        new TrackRequest   { UserId = "user-123", Event = "Signed Up" }
    ]
});
```
