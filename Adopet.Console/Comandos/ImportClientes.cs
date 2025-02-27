using Adopet.Console.Modelos;
using Adopet.Console.Results;
using Adopet.Console.Servicos.Abstracoes;
using FluentResults;

namespace Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import-clientes", documentacao: "adopet import-clientes <arquivo> comando que realiza a importação do arquivo de clientes.")]
    public class ImportClientes : IComando
    {
        private IApiService<Cliente> apiService;
        private ILeitorDeArquivo<Cliente> leitorDeArquivo;

        public ImportClientes(IApiService<Cliente> apiService, ILeitorDeArquivo<Cliente> leitor)
        {
            this.apiService = apiService;
            this.leitorDeArquivo = leitor;
        }

        public async Task<Result> ExecutarAsync()
        {
            try
            {
                var lista = leitorDeArquivo.RealizaLeitura();
                foreach (var cliente in lista)
                {
                    await apiService.CreateAsync(cliente);
                }
                return Result.Ok().WithSuccess(new SuccessWithClientes(lista, "Importação Realizada com Sucesso!"));
            }
            catch (Exception exception)
            {
                return Result.Fail(new Error("Importação falhou!").CausedBy(exception));
            }
        }
    }
}
