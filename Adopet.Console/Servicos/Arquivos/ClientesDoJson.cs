using Adopet.Console.Modelos;
using Adopet.Console.Servicos.Arquivos;

namespace Adopet.Testes.Servicos
{
    public class ClientesDoJson : LeitorDeArquivosJson<Cliente>
    {
        public ClientesDoJson(string caminhoDoArquivoASerLido) : base(caminhoDoArquivoASerLido)
        {
        }
    }
}