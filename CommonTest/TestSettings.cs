using DotNetEnv;

namespace SystemTests;

public static class TestSettings
{
    public static class Ozon
    {
        private const string DefaultDomain = "https://www.ozon.ru/";
        public static string Uri => GetString("PRODUCT_DOMAIN", DefaultDomain);
    }
    
    public static class Demoqa
    {
        private const string DefaultDomain = "https://demoqa.com/";
        public static Uri? Uri => new Uri(GetString("PRODUCT_DOMAIN", DefaultDomain));
    }
    
    public static class TimeoutSettings
    {
        public static TimeSpan TestCaseExecutionTimeoutMin = TimeSpan.FromMinutes(Env.GetInt("E2E_TEST_TIMEOUT", 60));
        public static TimeSpan HttpClientTimeout = TimeSpan.FromMinutes(Env.GetInt("HTTP_CLIENT_TIMEOUT", 5));
        public static TimeSpan BrowserCommandTimeout = TimeSpan.FromMinutes(Env.GetInt("BROWSER_COMMAND_TIMEOUT", 3));
    }
    
    private static string GetString(string key, string defaultValue)
    {
        return Environment.GetEnvironmentVariable(key) ?? defaultValue;
    }
    
    
}