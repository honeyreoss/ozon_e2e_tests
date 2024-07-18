using System.Net;
using Polly;
using Polly.Retry;

namespace ApiClient;

public class PolicyManager
{
    public static AsyncRetryPolicy<HttpResponseMessage> ApiClientRetryPolicy()
    {
        return Policy
            .HandleResult<HttpResponseMessage>(x =>
                x.StatusCode is HttpStatusCode.BadGateway or HttpStatusCode.InternalServerError
                    or HttpStatusCode.ServiceUnavailable &&
                x.RequestMessage != null &&
                !x.RequestMessage.Method.Equals(HttpMethod.Delete))
            .WaitAndRetryForeverAsync(
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(retryAttempt));
    }
}