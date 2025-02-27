using Adopet.Console.Servicos.Arquivos;
using Adopet.Console.Servicos.Http;
using Adopet.Console.Settings;

namespace Adopet.Console.Comandos
{
    public class ImportClientesFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(ImportClientes)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            var service = new ClienteService(new AdoPetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
            var leitorArquivoClientes = LeitorDeArquivoFactory.CreateLeitorDeClientes(argumentos[1]);
            if (leitorArquivoClientes is null) return null;
            return new ImportClientes(service, leitorArquivoClientes);
        }
    }
}
