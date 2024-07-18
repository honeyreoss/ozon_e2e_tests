using ApiClient;

namespace SystemTests;

public interface IApiAdapter: IDisposable
{
    Task<ClientsWrapper> GetCommonApi();
}

public sealed class ApiAdapter : IApiAdapter
{
    private readonly Lazy<Task<ClientsWrapper>> CommonApi;

    public ApiAdapter(IClientInitializer clientInitializer)
    {
        CommonApi = new Lazy<Task<ClientsWrapper>>(clientInitializer.InitializeClientsWrapper);
    }

    public async Task<ClientsWrapper> GetCommonApi()
    {
        return await CommonApi.Value;
    }

    public void Dispose()
    {
        if (CommonApi.IsValueCreated)
            CommonApi.Value.Dispose();
    }
}