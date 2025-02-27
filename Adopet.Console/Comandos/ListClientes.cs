using Adopet.Console.Modelos;
using Adopet.Console.Results;
using Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Adopet.Console.Comandos
{
    [DocComandoAttribute(
        instrucao: "list-clientes",
        documentacao: "adopet list-clientes comando que exibe no terminal o conteúdo cadastrado na base de dados da AdoPet.")]
    public class ListClientes : IComando    
    {
        private readonly IApiService<Cliente> service;

        public ListClientes(IApiService<Cliente> service)
        {
            this.service = service;
        }

        public async Task<Result> ExecutarAsync()
        {
            try
            {
                IEnumerable<Cliente>? clientes = await service.ListAsync();
                if (clientes == null)
                {
                    return Result.Fail(new Error("Nenhum cliente encontrado!"));
                }
                return Result.Ok().WithSuccess(new SuccessWithClientes(clientes, "Listagem de Clientes realizada com sucesso!"));
            }
            catch (Exception exception)
            {
                System.Console.WriteLine(exception);
                return Result.Fail(new Error("Listagem falhou!").CausedBy(exception));
            }
        }
    }
}
