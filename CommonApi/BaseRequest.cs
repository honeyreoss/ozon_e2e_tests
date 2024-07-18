namespace ApiClient
{
    public abstract class BaseRequest
    {
        public abstract void Process(HttpRequestMessage request);
    }

    public abstract class BaseRequest<T> : BaseRequest
    {
    }
}