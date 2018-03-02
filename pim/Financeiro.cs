using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim
{
    public class Financeiro : Funcionario
    {
        private int CupomFiscal;
        private DateTime DataVenda;

        private double CalcularCustoTotalCompra(Produto prod)
        {
            return 0;
        }
        private double  CalcularCustoTotalDeGastos(Produto prod)
        {
            return 0;
        }
        private float ComissaoVendas()
        {
            return 12f;
        }
        private void GerarRelatorioFaturamento()
        {

        }
    }
}
