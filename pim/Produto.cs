using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim
{
    public class Produto : Fornecedor
    {
        public int IDprod { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Tamanho { get; set; }
        public int QuantidadeProduto { get; set; }
        public float ValorCompraProd { get; set; }
        public float ValorVendaProd { get; set; }
        public int QuantidadeMaxEstoque { get; set; }
        public int QuantidadeMinEstoque { get; set; }
    }
}
