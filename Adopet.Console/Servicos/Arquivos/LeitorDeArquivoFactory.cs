
using Adopet.Console.Modelos;
using Adopet.Console.Servicos.Abstracoes;

namespace Adopet.Console.Servicos.Arquivos
{
    public static class LeitorDeArquivoFactory
    {
        public static ILeitorDeArquivo<Pet>? CreateLeitorDePets(string caminhoArquivo)
        {
            var extensao = Path.GetExtension(caminhoArquivo);
            switch (extensao)
            {
                case ".csv":
                    return new PetsDoCsv(caminhoArquivo);
                case ".json":
                    return new LeitorDeArquivosJson<Pet>(caminhoArquivo);
                default: return null;
            }
        }

        public static ILeitorDeArquivo<Cliente>? CreateLeitorDeClientes(string caminhoArquivo)
        {
            var extensao = Path.GetExtension(caminhoArquivo);
            switch (extensao)
            {
                case ".csv":
                    return new ClientesDoCsv(caminhoArquivo);
                case ".json":
                    return new LeitorDeArquivosJson<Cliente>(caminhoArquivo);
                default: return null;
            }
        }
    }
}