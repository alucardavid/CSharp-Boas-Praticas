using Adopet.Console.Modelos;
using Adopet.Console.Util;
using Moq;

namespace Adopet.Testes.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<LeitorDeArquivo> GetMock(List<Pet> listaDePet)
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default, It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            return leitorDeArquivo;
        }
    }
}
