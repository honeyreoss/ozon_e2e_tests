

using Polly.Retry;

namespace ApiClient;

public class HttpRetryMessageHandler : DelegatingHandler
{
    private readonly AsyncRetryPolicy<HttpResponseMessage> WaitAndRetryPolicy;
    public HttpRetryMessageHandler(HttpClientHandler handler, AsyncRetryPolicy<HttpResponseMessage> waitAndRetryPolicy) : base(handler)
    {
        WaitAndRetryPolicy = waitAndRetryPolicy;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken) =>
        WaitAndRetryPolicy.ExecuteAsync(async () => await base.SendAsync(request, cancellationToken));
}