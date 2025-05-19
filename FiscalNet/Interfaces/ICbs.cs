using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalNet.Interfaces
{
    public interface ICbs
    {
        decimal ValorBaseIbsCbs();
        decimal AliquotaEfetiva();
        decimal Diferimento();
        decimal ValorCbs();
    }
}
