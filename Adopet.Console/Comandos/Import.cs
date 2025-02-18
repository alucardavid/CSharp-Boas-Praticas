using Adopet.Console.Modelos;
using Adopet.Console.Servicos;
using Adopet.Console.Util;

namespace Adopet.Console.Comandos
{
    [DocComandoAttribute(instrucao: "import", documentacao: "adopet import <arquivo> comando que realiza a importação do arquivo de pets.")]
    public class Import : IComando
    {

        private readonly HttpClientPet clientPet;
        private readonly LeitorDeArquivo leitor;

        public Import(HttpClientPet clientPet, LeitorDeArquivo leitor)
        {
            this.clientPet = clientPet;
            this.leitor = leitor;
        }

        public async Task ExecutarAsync(string[] args)
        {
            await this.ImportacaoArquivoPetAsync();
        }

        private async Task ImportacaoArquivoPetAsync()
        {
            List<Pet> listaDePet = leitor.RealizaLeitura();
            foreach (var pet in listaDePet)
            {
                System.Console.WriteLine(pet);
                try
                {
                    await clientPet.CreatePetAsync(pet);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            System.Console.WriteLine("Importação concluída!");
        }

    }
}
