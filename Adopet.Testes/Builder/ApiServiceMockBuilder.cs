using Adopet.Console.Servicos.Abstracoes;
using Adopet.Console.Servicos.Http;
using Moq;

namespace Adopet.Testes.Builder
{
    internal class ApiServiceMockBuilder
    {
        public static Mock<IApiService<T>> GetMock<T>()
        {
            return new Mock<IApiService<T>>(MockBehavior.Default);
        }

        public static Mock<IApiService<T>> GetMockList<T>(List<T> lista)
        {
            var service = new Mock<IApiService<T>>(MockBehavior.Default);
            service.Setup(_ => _.ListAsync()).ReturnsAsync(lista);
            return service;
        }

    }
}
