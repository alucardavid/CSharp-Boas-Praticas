using Adopet.Console.Servicos.Arquivos;

namespace Adopet.Console.Comandos
{
    public class ShowFactory : IComandoFactory
    {
        public bool ConsegueCriarOTipo(Type? tipoComando)
        {
            return tipoComando?.IsAssignableTo(typeof(Show)) ?? false;
        }

        public IComando? CriarComando(string[] argumentos)
        {
            var leitorDeArquivos = argumentos.Length > 1 ? LeitorDeArquivoFactory.CreateLeitorDePets(argumentos[1]) : null;
            if (leitorDeArquivos is null) { return null; }
            return new Show(leitorDeArquivos);
        }
    }
}
