﻿using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adopet.Console.Comandos
{
    public interface IComando
    {
        Task<Result> ExecutarAsync();
    }
}
