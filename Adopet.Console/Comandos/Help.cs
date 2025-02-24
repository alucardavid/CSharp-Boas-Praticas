using Adopet.Console.Comandos;
using Adopet.Console.Util;
using FluentResults;
using System.Reflection;

[DocComandoAttribute(instrucao: "help", documentacao: "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
internal class Help : IComando
{
    private Dictionary<string, DocComandoAttribute> docs;
    private string? comando;
    public Help(string? comando)
    {
        docs = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttributes<DocComandoAttribute>().Any())
            .Select(t => t.GetCustomAttribute<DocComandoAttribute>()!)
            .ToDictionary(d => d.Instrucao);
        this.comando = comando;
    }

    public Task<Result> ExecutarAsync()
    {
        try
        {
            return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithDocs(this.GerarDocumentacao())));

        }
        catch (Exception ex)
        {
            return Task.FromResult(Result.Fail(new Error("Exibicao da documentacao falhou!").CausedBy(ex)));
        }
    }

    private IEnumerable<string> GerarDocumentacao()
    {
        List<string> resultado = new();
        // se não passou mais nenhum argumento mostra help de todos os comandos
        if (this.comando is null)
        {
            foreach (var doc in docs.Values)
            {
                resultado.Add(doc.Documentacao);
            }
        }
        // exibe o help daquele comando específico
        else 
        {
            if (docs.ContainsKey(this.comando))
            {
                var comando = docs[this.comando];
                resultado.Add(comando.Documentacao);
            }
            else
            {
                resultado.Add("Comando não encontrado!");
            }
        }

        return resultado;

    }
}