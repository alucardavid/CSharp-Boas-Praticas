using Adopet.Console.Comandos;
using System.Reflection;

[DocComandoAttribute(instrucao: "help", documentacao: "adopet help <NOME_COMANDO> para acessar a ajuda de um comando específico.")]
internal class Help : IComando
{
    private Dictionary<string, DocComandoAttribute> docs;

    public Help()
    {
        docs = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttributes<DocComandoAttribute>().Any())
            .Select(t => t.GetCustomAttribute<DocComandoAttribute>()!)
            .ToDictionary(d => d.Instrucao);
    }

    public Task ExecutarAsync(string[] args)
    {
        ExibirDocumentacao(args);
        return Task.CompletedTask;
    }

    private void ExibirDocumentacao(String[] args)
    {
        Console.WriteLine("Lista de comandos.");
        // se não passou mais nenhum argumento mostra help de todos os comandos
        if (args.Length == 1)
        {
            Console.WriteLine("adopet help <parametro> ous simplemente adopet help  " +
                 "comando que exibe informações de ajuda dos comandos.");
            Console.WriteLine("Adopet (1.0) - Aplicativo de linha de comando (CLI).");
            Console.WriteLine("Realiza a importação em lote de um arquivos de pets.");
            Console.WriteLine("Comando possíveis: ");

            foreach (var doc in docs.Values)
            {
                System.Console.WriteLine(doc.Documentacao);
            }


        }
        // exibe o help daquele comando específico
        else if (args.Length == 2)
        {
            string comandoASerExibido = args[1];
            if (docs.ContainsKey(comandoASerExibido))
            {
                var comando = docs[comandoASerExibido];
                System.Console.WriteLine(comando.Documentacao);
            }
        }
    }
}