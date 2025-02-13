
using Adopet.Console;
using Adopet.Console.Comandos;
using Adopet.Console.Modelos;
using Adopet.Console.Servicos;
using System.Net.Http.Headers;
using System.Net.Http.Json;

[DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo da base de dados da AdoPet.")]
internal class List : IComando
{
    private readonly HttpClientPet clientPet;

    public List(HttpClientPet clientPet)
    {
        this.clientPet = clientPet;
    }

    public async Task ExecutarAsync(string[] args)
    {
        await ListaDadosPetDaAPIAsync();
    }

    private async Task ListaDadosPetDaAPIAsync()
    {
        IEnumerable<Pet>? pets = await clientPet.ListPetsAsync();
        if (pets is not null)
        {
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
            }
        }
    }
}