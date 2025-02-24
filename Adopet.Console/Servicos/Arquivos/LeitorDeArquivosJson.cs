using Adopet.Console.Modelos;
using Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Adopet.Console.Servicos.Arquivos;
public class LeitorDeArquivosJson : ILeitorDeArquivos
{
    private string caminhoArquivo;
    public LeitorDeArquivosJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public IEnumerable<Pet> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        return JsonSerializer.Deserialize<IEnumerable<Pet>>(stream) ?? Enumerable.Empty<Pet>();
    }
}