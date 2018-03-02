using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pim
{
    public class Vendedor : Funcionario
    {
        public int IDuser { get; set; }
        public DateTime DataVenda { get; set; }
        public float TotalVenda { get; set; }
        public int IDForn_Prod { get; set; }

    }
}
