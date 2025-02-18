using Adopet.Console.Modelos;
using Adopet.Console.Util;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Testes.Builder
{
    internal static class LeitorDeArquivosMockBuilder
    {
        public static Mock<LeitorDeArquivo> CriaMock(List<Pet> listaDePet)
        {
            var leitorDeArquivo = new Mock<LeitorDeArquivo>(MockBehavior.Default, It.IsAny<string>());

            leitorDeArquivo.Setup(_ => _.RealizaLeitura()).Returns(listaDePet);

            return leitorDeArquivo;
        }
    }
}
