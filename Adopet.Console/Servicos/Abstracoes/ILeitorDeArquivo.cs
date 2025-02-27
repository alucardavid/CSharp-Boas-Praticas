namespace Adopet.Console.Servicos.Abstracoes;
public interface ILeitorDeArquivo<T>
{
    IEnumerable<T> RealizaLeitura();
}