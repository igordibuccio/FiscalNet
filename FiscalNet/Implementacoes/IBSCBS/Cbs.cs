using FiscalNet.Interfaces;
using System;

namespace FiscalNet.Implementacoes.IBSCBS
{
    public class Cbs : ICbs
    {
        public Cbs(decimal valorProduto,
            decimal valorServico = 0,
            decimal valorFrete = 0,
            decimal valorSeguro = 0,
            decimal despesasAcessorias = 0,
            decimal valorImpostoImportacao = 0,
            decimal valorDesconto = 0,
            decimal valorPis = 0,
            decimal valorCofins = 0,
            decimal valorIcms = 0,
            decimal valorIcmsUfDest = 0,
            decimal valorFcp = 0,
            decimal valorFcpUfDest = 0,
            decimal valorIcmsMonofasico = 0,
            decimal valorIssqn = 0,
            decimal valorIS = 0,
            decimal aliquotaCbs = 0,
            decimal reducaoCbs = 0,
            decimal diferimentoCbs = 0,
            decimal devolucaoTributo = 0)
        {
            ValorProduto = valorProduto;
            ValorServico = valorServico;
            ValorFrete = valorFrete;
            ValorSeguro = valorSeguro;
            DespesasAcessorias = despesasAcessorias;
            ValorImpostoImportacao = valorImpostoImportacao;
            ValorDesconto = valorDesconto;
            ValorPis = valorPis;
            ValorCofins = valorCofins;
            ValorIcms = valorIcms;
            ValorIcmsUfDest = valorIcmsUfDest;
            ValorFcp = valorFcp;
            ValorFcpUfDest = valorFcpUfDest;
            ValorIcmsMonofasico = valorIcmsMonofasico;
            ValorIssqn = valorIssqn;
            ValorIS = valorIS;
            AliquotaCbs = aliquotaCbs;
            ReducaoCbs = reducaoCbs;
            DiferimentoCbs = diferimentoCbs;
            DevolucaoTributo = devolucaoTributo;
            _BaseIbsCbs = new BaseIbsCbs(ValorProduto,
                                        ValorServico,
                                        ValorFrete,
                                        ValorSeguro,
                                        DespesasAcessorias,
                                        ValorImpostoImportacao,
                                        ValorDesconto,
                                        ValorPis,
                                        ValorCofins,
                                        ValorIcms,
                                        ValorIcmsUfDest,
                                        ValorFcp,
                                        ValorFcpUfDest,
                                        ValorIcmsMonofasico,
                                        ValorIssqn,
                                        ValorIS);
        }

        private decimal ValorProduto { get; set; }
        private decimal ValorServico { get; set; }
        private decimal ValorFrete { get; set; }
        private decimal ValorSeguro { get; set; }
        private decimal DespesasAcessorias { get; set; }
        private decimal ValorImpostoImportacao { get; set; }
        private decimal ValorDesconto { get; set; }
        private decimal ValorPis { get; set; }
        private decimal ValorCofins { get; set; }
        private decimal ValorIcms { get; set; }
        private decimal ValorIcmsUfDest { get; set; }
        private decimal ValorFcp { get; set; }
        private decimal ValorFcpUfDest { get; set; }
        private decimal ValorIcmsMonofasico { get; set; }
        private decimal ValorIssqn { get; set; }
        private decimal ValorIS { get; set; }
        private decimal AliquotaCbs { get; set; }
        private decimal ReducaoCbs { get; set; }
        private decimal DiferimentoCbs { get; set; }
        private decimal DevolucaoTributo { get; set; }

        private BaseIbsCbs _BaseIbsCbs { get; set; }

        public decimal ValorBaseIbsCbs()
        {
            return _BaseIbsCbs.CalcularBaseIbsCbs();
        }

        public decimal AliquotaEfetiva()
        {
            decimal aliquotaEfetivaCbs = 0;
            if (ReducaoCbs > 0)
                aliquotaEfetivaCbs = decimal.Round(((AliquotaCbs * (1 - ReducaoCbs)) / 100), 2, MidpointRounding.ToEven);
            else
                aliquotaEfetivaCbs = 0;

            return aliquotaEfetivaCbs;
        }

        public decimal Diferimento()
        {
            decimal valorDiferimento = decimal.Round((ValorBaseIbsCbs() * DiferimentoCbs / 100), 2, MidpointRounding.ToEven);
            return valorDiferimento;
        }

        public decimal ValorCbs()
        {
            //Base de Cálculo x Alíquota(vBC[tag: gIBSCBS / vBC] x pCBS) - vDif – vDevTrib
            decimal valorCbs = 0;
            if (ReducaoCbs > 0)
                valorCbs = decimal.Round(((ValorBaseIbsCbs() * (AliquotaEfetiva() / 100)) - Diferimento() - DevolucaoTributo), 2, MidpointRounding.ToEven);
            else
                valorCbs = decimal.Round(((ValorBaseIbsCbs() * (AliquotaCbs / 100)) - Diferimento() - DevolucaoTributo), 2, MidpointRounding.ToEven);

            return valorCbs;
        }
    }
}
