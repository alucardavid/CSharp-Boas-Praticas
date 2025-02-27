
using Adopet.Console.Servicos.Http;
using Adopet.Console.Settings;

namespace Adopet.Console.Comandos
{
    public class ListClientesFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(ListClientes)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            var clienteService = new ClienteService(new AdoPetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
            return new ListClientes(clienteService);
        }
    }
}
