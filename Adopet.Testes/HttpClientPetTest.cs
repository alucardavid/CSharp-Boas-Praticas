using Alura.Adopet.Console.Servicos;

namespace Adopet.Testes
{
    public class HttpClientPetTest
    {
        [Fact]
        public async Task ListaPetsDeveRetornarUmaListaNaoVazia()
        {
            // Arrange
            var clientePet = new HttpClientPet();

            // Act
            var lista = await clientePet.ListPetsAsync();
            // Assert

            Assert.NotNull(lista);
            Assert.NotEmpty(lista);
        }
    }
}