using FiscalNet.Implementacoes.IBSCBS;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FiscalNetTestes.IBSCBS
{
    [TestClass]
    public class IBSUFTest
    {
        [TestMethod]
        public void TestarIbsUf()
        {
            decimal valorProduto = 135.00M;
            decimal valorServico = 0;
            decimal valorFrete = 10.00M;
            decimal valorSeguro = 4.00M;
            decimal despesasAcessorias = 2.00M;
            decimal valorImpostoImportacao = 0;
            decimal valorDesconto = 5.00M;
            decimal valorPis = 1.98M;
            decimal valorCofins = 9.10M;
            decimal valorIcms = 26.28M;
            decimal valorIcmsUfDest = 0;
            decimal valorFcp = 2.92M;
            decimal valorFcpUfDest = 0;
            decimal valorIcmsMonofasico = 0;
            decimal valorIssqn = 0;
            decimal valorIS = 0;
            decimal aliquotaIbsUf = 0.1M;
            decimal reducaoIbsUf = 0;
            decimal diferimentoIbsUf = 0;
            decimal devolucaoTributo = 0;

            IbsUf ibsUf = new IbsUf(valorProduto,
                valorServico,
                valorFrete,
                valorSeguro,
                despesasAcessorias,
                valorImpostoImportacao,
                valorDesconto,
                valorPis,
                valorCofins,
                valorIcms,
                valorIcmsUfDest,
                valorFcp,
                valorFcpUfDest,
                valorIcmsMonofasico,
                valorIssqn,
                valorIS,
                aliquotaIbsUf,
                reducaoIbsUf,
                diferimentoIbsUf,
                devolucaoTributo);

            Assert.IsTrue(ibsUf.ValorBaseIbsCbs().Equals(105.72M));
            Assert.IsTrue(ibsUf.ValorIbsUf().Equals(0.11M));
        }
    }
}
