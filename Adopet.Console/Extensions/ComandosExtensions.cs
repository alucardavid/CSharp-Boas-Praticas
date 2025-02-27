using Adopet.Console.Comandos;
using System.Reflection;

namespace Adopet.Console.Extensions
{
    public static class ComandosExtensions
    {
        public static Type? GetTipoComando(this Assembly assembly, string instrucao)
        {
            return assembly
            .GetTypes()
            .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComando)))
            .FirstOrDefault(
                t => t.GetCustomAttributes<DocComandoAttribute>().Any(d => d.Instrucao.Equals(instrucao))
            );
        }

        public static IEnumerable<IComandoFactory?> GetFabricas(this Assembly assembly)
        {
            return assembly
                .GetTypes()
                // filtre os tipos concretos que implementam IComandoFactory
                .Where(t => !t.IsInterface && t.IsAssignableTo(typeof(IComandoFactory)))
                // criar instâncias de cada fábrica (não é o ideal)
                .Select(f => Activator.CreateInstance(f) as IComandoFactory);
        }
    }
}
