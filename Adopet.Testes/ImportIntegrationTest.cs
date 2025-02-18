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
    public class ImportIntegrationTest
    {
        [Fact]
        public async void QuandoAPIEstaNoArDeveRetornarListaDePet()
        {
            // Arrange
            var listaDePet = new List<Pet>();
            var pet = new Pet(new Guid("456b24f4-19e2-4423-845d-4a80e8854a41"),"Lima", TipoPet.Cachorro); //"456b24f4-19e2-4423-845d-4a80e8854a41; Lima Limão;1"; listaDePet.Add(pet);
            var leitorDeArquivo = LeitorDeArquivosMockBuilder.CriaMock(listaDePet);
            var httpClientPet = new HttpClientPet(new AdoPetAPIClientFactory().CreateClient("adopet"));
            var import = new Import(httpClientPet, leitorDeArquivo.Object);
            string[] args = ["import", "lista.csv"];

            // Act
            await import.ExecutarAsync(args);

            // Assert
            var listaPet = await httpClientPet.ListPetsAsync();
            Assert.NotNull(listaPet);
        }

    }
}
