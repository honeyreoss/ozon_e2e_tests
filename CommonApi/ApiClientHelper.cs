using Newtonsoft.Json;

namespace ApiClient;

public class ApiClientHelper
{
    private readonly HttpClient _httpClient;

    public ApiClientHelper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T> SendAsync<T>(HttpRequestMessage request)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
        catch (HttpRequestException ex)
        {
            throw new ApplicationException($"Network error: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            throw new ApplicationException($"An error occurred: {ex.Message}", ex);
        }
    }
}