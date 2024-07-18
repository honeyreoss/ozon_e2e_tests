using ApiClient;
using DemoqaApiClient.Models;

public sealed class GetBooksRequest : BaseRequest<List<Book>>
{
    public override void Process(HttpRequestMessage httpRequestMessage)
    {
        httpRequestMessage.Method = HttpMethod.Get;
        httpRequestMessage.RequestUri = new Uri($"BookStore/v1/Books", UriKind.Relative);
    }
}