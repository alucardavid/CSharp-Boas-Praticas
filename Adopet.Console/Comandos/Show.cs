using Adopet.Console.Comandos;
using Adopet.Console.Util;
using Adopet.Console;
using FluentResults;
using System.Diagnostics.CodeAnalysis;
using System;

[DocComandoAttribute(instrucao: "show", documentacao: "adopet show <ARQUIVO> comando que exibe no terminal o conteúdo do arquivo importado.")]
internal class Show : IComando
{
    private readonly LeitorDeArquivo leitor;
    public Show(LeitorDeArquivo leitor)
    {
        this.leitor = leitor;
    }

    public Task<Result> ExecutarAsync()
    {
        try
        {
            return this.ExibeConteudoArquivo();
        }
        catch (Exception ex)
        {

            return Task.FromResult(Result.Fail(new Error("Importação falhou!").CausedBy(ex)));
        }
    }

    private Task<Result> ExibeConteudoArquivo()
    {
        var listaPets = leitor.RealizaLeitura();
        
        return Task.FromResult(Result.Ok().WithSuccess(new SuccessWithPets(listaPets, "Conteúdo do arquivo exibido com sucesso!")));
    }
}