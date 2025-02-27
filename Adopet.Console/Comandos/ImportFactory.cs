using Adopet.Console.Servicos.Arquivos;
using Adopet.Console.Servicos.Http;
using Adopet.Console.Servicos.Mail;
using Adopet.Console.Settings;

namespace Adopet.Console.Comandos
{
    public class ImportFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(Import)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            var httpClientPet = new PetService(new AdoPetAPIClientFactory(Configurations.ApiSetting.Uri).CreateClient("adopet"));
            var leitorDeArquivos = argumentos.Length > 1 ? LeitorDeArquivoFactory.CreateLeitorDePets(argumentos[1]) : null;
            if (leitorDeArquivos is null) return null;
            var import = new Import(httpClientPet, leitorDeArquivos);
            import.DepoisDaExecucao += EnvioDeEmail.Disparar;
            return import;
        }
    }
}
