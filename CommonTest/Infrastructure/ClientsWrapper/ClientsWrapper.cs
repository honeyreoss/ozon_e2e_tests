using ApiClient.Clients;

namespace ApiClient;

public class ClientsWrapper
{
    public BookClient BookClient { get; }

    public ClientsWrapper(HttpClient client)
    {
        BookClient = new BookClient(client);
    }
}