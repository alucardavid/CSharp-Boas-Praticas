using Adopet.Console.Comandos;
using Adopet.Console.Util;
using Adopet.Console;

[DocComando(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    public Show()
    {
    }

    public Task ExecutarAsync(string[] args)
    {
        ExibeConteudoArquivo(caminhoDoArquivoASerExibido: args[1]);
        return Task.CompletedTask;
    }

    private void ExibeConteudoArquivo(string caminhoDoArquivoASerExibido)
    {
        LeitorArquivo leitor = new LeitorArquivo();
        var listaPets = leitor.RealizaLeitura(caminhoDoArquivoASerExibido);

        foreach (var pet in listaPets)
        {
            System.Console.WriteLine(pet);
        }
    }
}