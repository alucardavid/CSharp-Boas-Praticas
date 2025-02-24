using Adopet.Console.Modelos;
using Adopet.Console.Servicos;
using Adopet.Console.Util;
using FluentResults;

namespace Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {

        private readonly HttpClientPet clientPet;
        private readonly LeitorDeArquivo leitor;

        public Import(HttpClientPet clientPet, LeitorDeArquivo leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                List<Pet> listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {
                    await clientPet.CreatePetAsync(pet);
                }
                return Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importacao Realizada com Sucesso!"));
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Importacao Falhou!").CausedBy(ex));  
            }
        }

    }
}
