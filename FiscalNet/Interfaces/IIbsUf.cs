using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalNet.Interfaces
{
    public interface IIbsUf
    {
        decimal ValorBaseIbsCbs();
        decimal AliquotaEfetiva();
        decimal Diferimento();
        decimal ValorIbsUf();
    }
}
