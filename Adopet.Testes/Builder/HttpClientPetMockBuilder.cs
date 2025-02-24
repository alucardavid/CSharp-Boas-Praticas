using Adopet.Console.Servicos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Testes.Builder
{
    internal class HttpClientPetMockBuilder
    {
        public static Mock<HttpClientPet> GetMock()
        {
            var httpClientPet = new Mock<HttpClientPet>(MockBehavior.Default,
                It.IsAny<HttpClient>());

            return httpClientPet;
        }
    }
}
