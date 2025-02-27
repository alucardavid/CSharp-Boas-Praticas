using Adopet.Console.Comandos;

namespace Adopet.Testes.Comandos
{
    public class FabricaDeComandosTest
    {
        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoImport()
        {
            //Arrange
            string[] args = { "import", "lista.csv" };
            //Act
            var comando = ComandosFactory.CriarComando(args);
            //Assert
            Assert.IsType<Import>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoList()
        {
            //Arrange
            string[] args = { "list", "lista.csv" };
            //Act
            var comando = ComandosFactory.CriarComando(args);
            //Assert
            Assert.IsType<List>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoShow()
        {
            //Arrange
            string[] args = { "show", "lista.csv" };
            //Act
            var comando = ComandosFactory.CriarComando(args);
            //Assert
            Assert.IsType<Show>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarUmTipoHelp()
        {
            //Arrange
            string[] args = { "help", "list" };
            //Act
            var comando = ComandosFactory.CriarComando(args);
            //Assert
            Assert.IsType<Adopet.Console.Comandos.Help>(comando);
        }

        [Fact]
        public void DadoUmParametroDeveRetornarTipoImportClientes()
        {
            //Arrange
            string[] args = { "import-clientes", "clientes.csv" };
            //Act
            var comando = ComandosFactory.CriarComando(args);
            //Assert
            Assert.IsType<ImportClientes>(comando);
        }

        [Fact]
        public void DadoUmParametroInvalidoDeveRetornarNulo()
        {
            //Arrange
            string[] args = { "invalid", "lista.csv" };
            //Act
            var comando = ComandosFactory.CriarComando(args);
            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosNuloDeveRetornarNulo()
        {
            //Arrange           
            //Act
            var comando = ComandosFactory.CriarComando(null);
            //Assert
            Assert.Null(comando);
        }

        [Fact]
        public void DadoUmArrayDeArgumentosVazioDeveRetornarNulo()
        {
            //Arrange
            string[] args = { };
            //Act
            var comando = ComandosFactory.CriarComando(args);
            //Assert
            Assert.Null(comando);
        }

        [Theory]
        [InlineData("import", "Import")]
        [InlineData("list", "List")]
        [InlineData("show", "Show")]
        [InlineData("help", "Help")]
        [InlineData("import-clientes", "ImportClientes")]
        public void DadoParametroValidoDeveRetornarObjetoNaoNulo(string instrucao, string nomeTipo)
        {
            // Arrange
            string[] args = new[] { instrucao, "lista.csv" };

            // Act
            var comando = ComandosFactory.CriarComando(args);

            // Assert
            Assert.NotNull(comando);
            Assert.Equal(nomeTipo, comando.GetType().Name);
        }


    }
}
