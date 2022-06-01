using FiscalNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalNet.Implementacoes.PIS
{
    public class Pis01_02 : IPis01_02
    {
        private decimal ValorProduto { get; set; }
        private decimal ValorFrete { get; set; }
        private decimal ValorSeguro { get; set; }
        private decimal DespesasAcessorias { get; set; }
        private decimal ValorDesconto { get; set; }
        private decimal AliquotaPIS { get; set; }
        private BasePIS BasePIS { get; set; }

        public Pis01_02(decimal valorProduto,
            decimal valorFrete,
            decimal valorSeguro,
            decimal despesasAcessorias,
            decimal valorDesconto,
            decimal aliquotaPIS)
        {
            this.ValorProduto = valorProduto;
            this.ValorFrete = valorFrete;
            this.ValorSeguro = valorSeguro;
            this.DespesasAcessorias = despesasAcessorias;
            this.ValorDesconto = valorDesconto;
            this.AliquotaPIS = aliquotaPIS;
            this.BasePIS = new BasePIS(ValorProduto, ValorFrete, ValorSeguro,
                DespesasAcessorias, ValorDesconto);
        }

        public decimal BasePis()
        {
            return decimal.Round(BasePIS.CalcularBasePIS(),2);
        }

        public decimal ValorPis()
        {
            return decimal.Round((BasePis() * (AliquotaPIS/100)),2);
        }
    }
}
