using DemoqaApiClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ApiClient.Clients;

public class BookClient : BaseClient<List<Book>>
{
    public BookClient(HttpClient httpClient) : base(httpClient)
    {
    }
    
    public async Task<List<Book>> GetBooksAsync()
    {
        return await SendAsync<HttpRequestMessage>(new GetBooksRequest());
    }
    
    public async override Task<List<Book>> DeserializeResponse(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        var jObject = JObject.Parse(content);
        var booksToken = jObject["books"];  // Извлечение массива книг по ключу "books"
        return JsonConvert.DeserializeObject<List<Book>>(booksToken.ToString());  // Десериализация массива книг в список объектов Book
    }
}