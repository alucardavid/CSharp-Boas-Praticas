using Adopet.Console.Comandos;
using Adopet.Console.Modelos;
using Adopet.Console.Servicos;
using Adopet.Console.Util;
using Adopet.Testes.Builder;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Testes
{
    public class ImportTest
    {
        [Fact]
        public async void QuandoListaVaziaNaoDeveChamarCreatPetAsync()
        {
            // Arrange
            var listaDePet = new List<Pet>();
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.CriaMock(listaDePet);
            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default, It.IsAny<HttpClient>());
            var import = new Import(httpClientPet.Object, leitorDeArquivo.Object);
            string[] args = { "import", "lista.csv" };

            // Act
            await import.ExecutarAsync(args);

            // Assert
            httpClientPet.Verify(_ => _.CreatePetAsync(It.IsAny<Pet>()), Times.Never);
        }
    }
}
