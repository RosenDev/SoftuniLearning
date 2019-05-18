namespace SIS.HTTP.Headers.Interfaces
{
    public interface IHttpHeaderCollection
    {
        void AddHeader(HttpHeader header);
        bool ContainsHeader(string header);
        HttpHeader GetHeader(string header);

    }

  
}