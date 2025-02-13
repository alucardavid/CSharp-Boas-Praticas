using Adopet.Console.Modelos;

namespace Adopet.Console.Util
{
    internal class LeitorArquivo
    {
        public LeitorArquivo()
        {
        }

        internal List<Pet> RealizaLeitura(string caminhoDoArquivoDeImportacao)
        {
            List<Pet> listaDePet = new List<Pet>();

            using (StreamReader sr = new StreamReader(caminhoDoArquivoDeImportacao))
            {
                while (!sr.EndOfStream)
                {
                    // separa linha usando ponto e vírgula
                    string[] propriedades = sr.ReadLine().Split(';');
                    // cria objeto Pet a partir da separação
                    Pet pet = new Pet(Guid.Parse(propriedades[0]),
                        propriedades[1],
                        TipoPet.Cachorro
                    );

                    listaDePet.Add(pet);
                }
            }

            return listaDePet;
        }
    }
}