using Adopet.Console.Servicos.Http;
using Adopet.Console.Settings;

namespace Adopet.Console.Comandos
{
    public class ListFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(List)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            var httpClientPet = new PetService(new AdoPetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
            return new List(httpClientPet);
        }
    }
}
