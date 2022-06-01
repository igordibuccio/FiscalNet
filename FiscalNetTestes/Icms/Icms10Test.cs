using FiscalNet.Implementacoes.Icms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiscalNetTestes.Icms
{
    [TestClass]
    public class Icms10Test
    {
        [TestMethod]
        public void TestarIcms10()
        {
            decimal valorProduto = 135.00M;
            decimal valorFrete = 7.50M;
            decimal valorSeguro = 3.00M;
            decimal despesasAcessorias = 1.50M;
            decimal valorDesconto = 13.50M;
            decimal valorIpi = 15.00M;
            decimal aliquotaIcmsProprio = 12.00M;
            decimal aliquotaIcmsST = 18.00M;
            decimal mva = 40.65M;
            decimal percentualReducaoST = 10;

            Icms10 icms10 = new Icms10(valorProduto, valorFrete, valorSeguro, despesasAcessorias,
                valorIpi, valorDesconto, aliquotaIcmsProprio, aliquotaIcmsST, mva, percentualReducaoST);

            decimal vBC = icms10.BaseIcmsProprio();

            decimal vICMS = icms10.ValorIcmsProprio();

            decimal vBCST = icms10.BaseIcmsST();

            decimal vICMSST = icms10.ValorIcmsST();

            decimal vICMSSTDeson = icms10.ValorICMSSTDesonerado();

            Assert.IsTrue(vBC.Equals(133.50M));
            Assert.IsTrue(vICMS.Equals(16.02M));
            Assert.IsTrue(vBCST.Equals(183.99M));
            Assert.IsTrue(vICMSST.Equals(17.10M));
        }

    }
}
