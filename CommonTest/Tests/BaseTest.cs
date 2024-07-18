using ApiClient;
using Autofac;

namespace SystemTests;

public class BaseTest
{
    private readonly ContainerBuilder ContainerBuilder = new();
    private IContainer Container;
    private HttpClient HttpClient;
    protected IApiAdapter ApiAdapter => Container!.Resolve<IApiAdapter>();
    protected ClientsWrapper CommonApi { get; set; }
    
    
    [TestInitialize]
    public async Task TestSetup()
    {

        HttpClient = InitializeHttpClient();
        ContainerBuilder.ConfigureServices(HttpClient);
        Container = ContainerBuilder.Build();
        CommonApi = await ApiAdapter.GetCommonApi();
    }

    private HttpClient InitializeHttpClient()
    {
        return new HttpClient(new HttpRetryMessageHandler(new HttpClientHandler(), PolicyManager.ApiClientRetryPolicy()))
        {
            BaseAddress = TestSettings.Demoqa.Uri,
            Timeout = TestSettings.TimeoutSettings.HttpClientTimeout
        };
    }
}