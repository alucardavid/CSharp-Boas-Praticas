using Adopet.Console.Modelos;
using Adopet.Console.Servicos.Abstracoes;
using System.Net.Http.Json;

namespace Adopet.Console.Servicos.Http
{
    public class ClienteService : IApiService<Cliente>
    {
        private HttpClient client = new();

        public ClienteService(HttpClient client)
        {
            this.client = client;
        }

        public Task CreateAsync(Cliente cliente)
        {
            return client.PostAsJsonAsync("cliente/add", cliente);
        }

        public async Task<IEnumerable<Cliente>?> ListAsync()
        {
            HttpResponseMessage response = await client.GetAsync("cliente/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Cliente>>();
        }
    }
}
