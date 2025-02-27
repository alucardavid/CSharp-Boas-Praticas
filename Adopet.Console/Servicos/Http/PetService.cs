using System.Net.Http.Json;
using Adopet.Console.Modelos;
using Adopet.Console.Servicos.Abstracoes;

namespace Adopet.Console.Servicos.Http
{
    public class PetService : IApiService<Pet>
    {
        private HttpClient client = new();
        public PetService(HttpClient client)
        {
            this.client = client;
        }

        public virtual Task CreateAsync(Pet pet)
        {
            return client.PostAsJsonAsync("pet/add", pet);
        }

        public async Task<IEnumerable<Pet>?> ListAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }
    }
}