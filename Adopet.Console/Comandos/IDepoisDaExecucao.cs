using FluentResults;

namespace Adopet.Console.Comandos
{
    public interface IDepoisDaExecucao
    {
        event Action<Result>? DepoisDaExecucao;
    }
}
