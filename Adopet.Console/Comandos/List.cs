
using Adopet.Console;
using Adopet.Console.Comandos;
using Adopet.Console.Modelos;
using Adopet.Console.Servicos;
using Adopet.Console.Util;
using FluentResults;
using System.Net.Http.Headers;
using System.Net.Http.Json;

[DocComandoAttribute(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo da base de dados da AdoPet.")]
internal class List : IComando
{
    private readonly HttpClientPet clientPet;

    public List(HttpClientPet clientPet)
    {
        this.clientPet = clientPet;
    }

    public async Task<Result> ExecutarAsync()
    {
        return await ListaDadosPetDaAPIAsync();
    }

    private async Task<Result> ListaDadosPetDaAPIAsync()
    {
        IEnumerable<Pet>? pets = await clientPet.ListPetsAsync();
        if (pets is not null)
        {
            return Result.Ok().WithSuccess(new SuccessWithPets(pets, "Pets Listados Com Sucesso!"));
        }

        return Result.Ok().WithSuccess("Nenhum pet");

    }
}