using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Console.Results
{
    public class SuccessWithDocs : Success
    {
        public IEnumerable<string> Documentacao { get; }
        public SuccessWithDocs(IEnumerable<string> documentacao)
        {
            Documentacao = documentacao;
        }


    }
}
