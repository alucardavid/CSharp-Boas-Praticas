using Adopet.Console.Servicos;
using Adopet.Console.Servicos.Arquivos;

namespace Adopet.Console.Comandos
{
    internal static class ComandosFactory
    {
        public static IComando? CriarComando(string[] argumentos)
        {
            if (argumentos == null || argumentos.Length == 0)
            {
                return null;
            }


            var comando = argumentos[0];
            var httpClientPet = new HttpClientPet(new AdoPetAPIClientFactory().CreateClient("adopet"));
            LeitorDeArquivoCsv? leitorDeArquivos = argumentos.Length == 2 ? new(argumentos[1]) : null;

            switch (comando)
            {
                case "import":
                    if (leitorDeArquivos == null)
                    {
                        throw new ArgumentNullException(nameof(leitorDeArquivos), "Leitor de arquivos não pode ser nulo para o comando 'import'.");
                    }
                    return new Import(httpClientPet, leitorDeArquivos);
                case "list":
                    return new List(httpClientPet);
                case "show":
                    if (leitorDeArquivos == null)
                    {
                        throw new ArgumentNullException(nameof(leitorDeArquivos), "Leitor de arquivos não pode ser nulo para o comando 'import'.");
                    }
                    return new Show(leitorDeArquivos);
                case "help":
                    if (argumentos.Length < 2)
                    {
                        throw new ArgumentException("O comando 'help' deve ser seguido de um comando para exibir a ajuda.");
                    }
                    return new Help(comando: comando);
                default: return null;
            }
        }
    }
}
