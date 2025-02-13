﻿
using Adopet.Console.Modelos;
using Newtonsoft.Json.Linq;

namespace Adopet.Testes
{
    public class PetAPartirDoCsvTest
    {
        [Fact]
        public void QuandoStringForValidaDeveRetornarUmPet()
        {
            // Arrange
            string linha = "456b24f4-19e2-4423-845d-4a80e8854a41;Lima Limão;1";

            // Act
            Pet pet = linha.ConverteDoTexto();

            // Assert
            Assert.NotNull(pet);
        }
    }
}
