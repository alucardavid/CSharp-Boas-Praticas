
using Adopet.Console;
using Adopet.Console.Comandos;
using Adopet.Console.Modelos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo da base de dados da AdoPet.")]
internal class List : IComando
{
    HttpClient client;

    public List()
    {
        this.client = ConfiguraHttpClient("http://localhost:5057");
    }
    public async Task ExecutarAsync(string[] args)
    {
        await ListaDadosPetDaAPIAsync();
    }

    private async Task ListaDadosPetDaAPIAsync()
    {
        var pets = await ListPetsAsync();
        if (pets is not null)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
            }
        }
    }
    async Task<IEnumerable<Pet>?> ListPetsAsync()
    {
        HttpResponseMessage response = await client.GetAsync("pet/list");
        return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
    }

    HttpClient ConfiguraHttpClient(string url)
    {
        HttpClient _client = new HttpClient();
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        _client.BaseAddress = new Uri(url);
        return _client;
    }

}