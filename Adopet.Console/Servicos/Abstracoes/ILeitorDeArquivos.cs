using Adopet.Console.Modelos;

namespace Adopet.Console.Servicos.Abstracoes;
public interface ILeitorDeArquivos
{
    IEnumerable<Pet> RealizaLeitura();
}