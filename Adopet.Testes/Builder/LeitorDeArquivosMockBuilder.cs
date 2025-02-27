using Adopet.Console.Modelos;
using Adopet.Console.Servicos.Arquivos;
using Moq;

namespace Adopet.Testes.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<LeitorDeArquivoCsv<T>> GetMock<T>(List<T> lista)
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivoCsv<T>>(MockBehavior.Default, It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(lista);

            return leitorDeArquivo;
        }
    }
}
