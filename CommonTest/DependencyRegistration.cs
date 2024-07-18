using Autofac;
using SystemTests;

namespace ApiClient;

public static class DependencyRegistration
{
    public static void ConfigureServices(this ContainerBuilder builder, HttpClient httpClient)
    {
        builder.Register(_ => httpClient)
            .SingleInstance();

        builder.RegisterType<ClientInitializer>()
            .As<IClientInitializer>()
            .SingleInstance();
        
        builder.RegisterType<ApiAdapter>()
            .As<IApiAdapter>()
            .SingleInstance();
    }
}