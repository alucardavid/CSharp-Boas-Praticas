using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Console.Comandos
{
    internal class ComandosDoSistema
    {
        private Dictionary<string, IComando> comandosDoSistema = new()
        {
            { "import", new Import() },
            { "show", new Show() },
            { "list", new List() },
            { "help", new Help() }
        };

        public IComando? this [string key] => comandosDoSistema.ContainsKey(key) ? comandosDoSistema[key] : null;
    }
}
