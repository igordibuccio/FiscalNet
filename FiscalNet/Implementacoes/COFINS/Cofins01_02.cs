using FiscalNet.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiscalNet.Implementacoes.COFINS
{
    public class Cofins01_02 : ICofins01_02
    {
        private decimal ValorProduto { get; set; }
        private decimal ValorFrete { get; set; }
        private decimal ValorSeguro { get; set; }
        private decimal DespesasAcessorias { get; set; }
        private decimal ValorDesconto { get; set; }
        private decimal AliquotaCofins { get; set; }
        private BaseCofins BaseCOFINS { get; set; }

        public Cofins01_02(decimal valorProduto,
            decimal valorFrete,
            decimal valorSeguro,
            decimal despesasAcessorias,
            decimal valorDesconto,
            decimal aliquotaCOFINS)
        {
            this.ValorProduto = valorProduto;
            this.ValorFrete = valorFrete;
            this.ValorSeguro = valorSeguro;
            this.DespesasAcessorias = despesasAcessorias;
            this.ValorDesconto = valorDesconto;
            this.AliquotaCofins = aliquotaCOFINS;
            this.BaseCOFINS = new BaseCofins(ValorProduto, ValorFrete, ValorSeguro,
                DespesasAcessorias, ValorDesconto);
        }

        public decimal BaseCofins()
        {
            return decimal.Round(BaseCOFINS.CalcularBaseCofins(), 2);
        }

        public decimal ValorCofins()
        {
            return decimal.Round((BaseCofins() * (AliquotaCofins / 100)), 2);
        }
    }
}
