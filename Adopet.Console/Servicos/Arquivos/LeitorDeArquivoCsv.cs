using Adopet.Console.Modelos;
using Adopet.Console.Servicos.Abstracoes;

namespace Adopet.Console.Servicos.Arquivos;

public abstract class LeitorDeArquivoCsv<T> : ILeitorDeArquivo<T>
{
    private string caminhoDoArquivoASerLido;
    public LeitorDeArquivoCsv(string caminhoDoArquivoASerLido)
    {
        this.caminhoDoArquivoASerLido = caminhoDoArquivoASerLido;
    }

    public virtual IEnumerable<T> RealizaLeitura()
    {
        List<T> lista = new List<T>();
        using StreamReader sr = new StreamReader(caminhoDoArquivoASerLido);

        while (!sr.EndOfStream)
        {
            string? linha = sr.ReadLine();
            if (linha is not null)
            {
                string[] propriedades = linha.Split(';');
                var objeto = CriarDaLinhaCsv(linha);
                //bool guidValido = Guid.TryParse(propriedades[0], out Guid petId);
                //if (!guidValido) throw new ArgumentException("Identificador do pet inválido!");

                //bool tipoValido = int.TryParse(propriedades[2], out int tipoPet);
                //if (!tipoValido) throw new ArgumentException("Tipo do pet inválido!");

                //TipoPet tipo = tipoPet == 1 ? TipoPet.Gato : TipoPet.Cachorro;

                lista.Add(objeto);
            }
        }
        return lista;
    }

    public abstract T CriarDaLinhaCsv(string linha);
    
}