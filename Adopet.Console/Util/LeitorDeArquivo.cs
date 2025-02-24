using Adopet.Console.Modelos;

namespace Adopet.Console.Util
{
    public class LeitorDeArquivo
    {
        private string caminhoDoArquivoDeImportacao;

        public LeitorDeArquivo(string caminhoDoArquivoDeImportacao)
        {
            this.caminhoDoArquivoDeImportacao = caminhoDoArquivoDeImportacao;
        }

        public virtual List<Pet> RealizaLeitura()
        {
            List<Pet> listaDePet = new List<Pet>();

            using (StreamReader sr = new StreamReader(this.caminhoDoArquivoDeImportacao))
            {
                while (!sr.EndOfStream)
                {
                    string? linha = sr.ReadLine();
                    if (linha != null)
                    {
                        // separa linha usando ponto e vírgula
                        string[] propriedades = linha.Split(';');
                        // cria objeto Pet a partir da separação
                        Pet pet = new Pet(Guid.Parse(propriedades[0]),
                            propriedades[1],
                            TipoPet.Cachorro
                        );

                        listaDePet.Add(pet);
                    }
                }
            }

            return listaDePet;
        }
    }
}