namespace ApiClient;

public interface IClientInitializer
{
    Task<ClientsWrapper> InitializeClientsWrapper();
}

public class ClientInitializer : IClientInitializer
{
    private readonly HttpClient HttpClient;

    public ClientInitializer(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    public async Task<ClientsWrapper> InitializeClientsWrapper() => await ClientsWrapperFactory.CreateClientsWrapper(HttpClient);
}