using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pim
{
    public partial class ConsultarProdutos : Form
    {
        public Principal prin { get; set; }

        public ConsultarProdutos()
        {
            InitializeComponent();
        }


        public DataTable ConsultaTodosProdutos()
        {
            DataTable dt = null;

            try
            {
                Funcionario func = new Funcionario();
                dt = func.ConsultaTodosProdutos();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            return dt;
        }


        public void PopulaGrid()
        {
            dgConsultarPROD.DataSource = ConsultaTodosProdutos();

        }

        private void ConsultarProdutos_Load(object sender, EventArgs e)
        {
            PopulaGrid();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (prin != null)
                {
                    if (dgConsultarPROD.SelectedRows.Count > 0)
                    {
                        prin.vendaIDPROD.Text = dgConsultarPROD.SelectedRows[0].Cells["IDProd"].Value.ToString();
                        prin.vendaCategoria.Text = dgConsultarPROD.SelectedRows[0].Cells["Categoria"].Value.ToString();
                        prin.vendaMarca.Text = dgConsultarPROD.SelectedRows[0].Cells["Marca"].Value.ToString();
                        prin.vendaTamanho.Text = dgConsultarPROD.SelectedRows[0].Cells["Tamanho"].Value.ToString();
                        prin.vendaCompraPROD.Value = Convert.ToInt32(dgConsultarPROD.SelectedRows[0].Cells["ValorVendaProd"].Value);
                        prin.vendaQtdPRODEstoque.Text = dgConsultarPROD.SelectedRows[0].Cells["QuantidadeProduto"].Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            this.Close();
        }
    }
}
