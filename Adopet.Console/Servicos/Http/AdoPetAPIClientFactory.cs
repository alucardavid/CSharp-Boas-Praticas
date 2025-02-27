using System.Net.Http.Headers;

namespace Adopet.Console.Servicos.Http
{
    public class AdoPetAPIClientFactory : IHttpClientFactory
    {

        private string uri;

        public AdoPetAPIClientFactory(string uri)
        {
            this.uri = uri;
        }

        public HttpClient CreateClient(string name)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(uri);
            return _client;
        }
    }
}
