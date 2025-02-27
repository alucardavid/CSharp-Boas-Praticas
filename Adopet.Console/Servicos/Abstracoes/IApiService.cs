using Adopet.Console.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Console.Servicos.Abstracoes
{
    public interface IApiService<T>
    {
        Task CreateAsync(T obj);
        Task<IEnumerable<T>?> ListAsync();
    }
}
