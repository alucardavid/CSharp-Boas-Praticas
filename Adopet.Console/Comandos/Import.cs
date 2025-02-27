using Adopet.Console.Modelos;
using Adopet.Console.Results;
using Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando, IDepoisDaExecucao
    {

        private readonly IApiService<Pet> clientPet;
        private readonly ILeitorDeArquivo<Pet> leitor;

        public Import(IApiService<Pet> clientPet, ILeitorDeArquivo<Pet> leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public event Action<Result>? DepoisDaExecucao;

        public async Task<Result> ExecutarAsync()
        {
            return await this.ImportacaoArquivoPetAsync();
        }

        private async Task<Result> ImportacaoArquivoPetAsync()
        {
            try
            {
                var listaDePet = leitor.RealizaLeitura();
                foreach (var pet in listaDePet)
                {
                    await clientPet.CreateAsync(pet);
                }
                var resultado = Result.Ok().WithSuccess(new SuccessWithPets(listaDePet, "Importacao Realizada com Sucesso!"));
                DepoisDaExecucao?.Invoke(resultado);
                return resultado;
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Importacao Falhou!").CausedBy(ex));  
            }
        }

    }
}
