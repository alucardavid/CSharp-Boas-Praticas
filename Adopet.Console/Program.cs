using Adopet.Console.Comandos;
using Adopet.Console.Servicos;
using Adopet.Console.UI;
using Adopet.Console.Util;
using FluentResults;

try
{
    IComando? comando = ComandosFactory.CriarComando(args);
    if (comando is not null)
    {
        var resultado = await comando.ExecutarAsync();
        ConsoleUI.ExibeResultado(resultado);
    }
    else
    {
        ConsoleUI.ExibeResultado(Result.Fail("Comando Invalido!"));
    }
}
finally
{
    Console.ResetColor();
}
