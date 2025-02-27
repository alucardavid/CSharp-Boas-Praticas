using Adopet.Console.Servicos.Abstracoes;
using System.Text.Json;

namespace Adopet.Console.Servicos.Arquivos;
public class LeitorDeArquivosJson<T> : ILeitorDeArquivo<T>
{
    private string caminhoArquivo;
    public LeitorDeArquivosJson(string caminhoArquivo)
    {
        this.caminhoArquivo = caminhoArquivo;
    }

    public IEnumerable<T> RealizaLeitura()
    {
        using var stream = new FileStream(caminhoArquivo, FileMode.Open, FileAccess.Read);
        var jsonOptions = new JsonSerializerOptions();

        jsonOptions.PropertyNameCaseInsensitive = true;
        return JsonSerializer.Deserialize<IEnumerable<T>>(stream, jsonOptions) ?? Enumerable.Empty<T>();
    }
}