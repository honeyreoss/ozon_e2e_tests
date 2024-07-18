using ApiClient;

interface IDeserializerResponse<T>
{
    Task<T> DeserializeResponse(HttpResponseMessage response);
}

public class BaseClient<T> : IDeserializerResponse<T>
{
    protected HttpClient client;

    public BaseClient(HttpClient httpClient)
    {
        client = httpClient;
    }

    public async Task<T> SendAsync<TRequest>(BaseRequest request)
        where TRequest : HttpRequestMessage
    {
        var response = await SendAsync(request);
        return await DeserializeResponse(response);
    }

    private async Task<HttpResponseMessage> SendAsync(BaseRequest request)
    {
        var requestMessage = new HttpRequestMessage();
        request.Process(requestMessage);
        return await client.SendAsync(requestMessage);
    }
    
    public virtual async Task<T> DeserializeResponse(HttpResponseMessage response)
    {
        throw new NotImplementedException();
    }
}