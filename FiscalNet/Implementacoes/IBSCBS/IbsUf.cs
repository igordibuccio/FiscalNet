using FiscalNet.Interfaces;
using System;

namespace FiscalNet.Implementacoes.IBSCBS
{
    public class IbsUf : IIbsUf
    {
        public IbsUf(decimal valorProduto,
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
            decimal aliquotaIbsUf = 0,
            decimal reducaoIbsUf = 0,
            decimal diferimentoIbsUf = 0,
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
            AliquotaIbsUf = aliquotaIbsUf;
            ReducaoIbsUf = reducaoIbsUf;            
            DiferimentoIbsUf = diferimentoIbsUf;
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
        private decimal AliquotaIbsUf { get; set; }
        private decimal ReducaoIbsUf { get; set; }
        private decimal DiferimentoIbsUf { get; set; }
        private decimal DevolucaoTributo { get; set; }

        private BaseIbsCbs _BaseIbsCbs { get; set; }

        public decimal ValorBaseIbsCbs()
        {
            return _BaseIbsCbs.CalcularBaseIbsCbs();
        }

        public decimal AliquotaEfetiva()
        {
            decimal aliquotaEfetivaIbsUf = 0;
            if (ReducaoIbsUf > 0)
                aliquotaEfetivaIbsUf = decimal.Round(((AliquotaIbsUf * (1 - ReducaoIbsUf)) / 100), 2, MidpointRounding.ToEven);
            else
                aliquotaEfetivaIbsUf = 0;

            return aliquotaEfetivaIbsUf;
        }

        public decimal Diferimento()
        {
            decimal valorDiferimento = decimal.Round((ValorBaseIbsCbs() * DiferimentoIbsUf / 100), 2, MidpointRounding.ToEven);
            return valorDiferimento;
        }

        public decimal ValorIbsUf()
        {
            //Base de Cálculo x Alíquota(vBC[tag: gIBSCBS / vBC] x pIBSUF) - vDif – vDevTrib
            decimal valorIbsUf = 0;
            if (ReducaoIbsUf > 0)
                valorIbsUf = decimal.Round(((ValorBaseIbsCbs() * (AliquotaEfetiva() / 100)) - Diferimento() - DevolucaoTributo), 2, MidpointRounding.ToEven);
            else
                valorIbsUf = decimal.Round(((ValorBaseIbsCbs() * (AliquotaIbsUf / 100)) - Diferimento() - DevolucaoTributo), 2, MidpointRounding.ToEven);

            return valorIbsUf;
        }
    }
}
