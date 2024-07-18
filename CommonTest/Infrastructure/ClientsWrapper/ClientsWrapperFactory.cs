namespace ApiClient;

public static class ClientsWrapperFactory
{
    public static async Task<ClientsWrapper> CreateClientsWrapper(HttpClient httpClient)
    {
        var api = new ClientsWrapper(httpClient);

        return api;
    }
}
    