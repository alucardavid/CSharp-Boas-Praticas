using Adopet.Console.Comandos;
using Adopet.Console.UI;
using FluentResults;

try
{
    IComando? comando = ComandosFactory.CriarComando(args);
    if (comando is not null)
    {
        System.Console.WriteLine(comando);
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
