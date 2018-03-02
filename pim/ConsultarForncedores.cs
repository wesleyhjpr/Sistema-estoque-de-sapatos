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
    public partial class ConsultarForncedores : Form
    {
        public Principal prin { get; set; }
        public ConsultarForncedores()
        {
            InitializeComponent();
        }
        public DataTable ConsultaTodosFornecedores()
        {
            DataTable dt = null;

            try
            {
                Gerente gr = new Gerente();
                dt = gr.LerTodosFornecedores();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            return dt;
        }


        public void PopulaGrid()
        {
            dgListaFornec.DataSource = ConsultaTodosFornecedores();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (prin != null)
                {
                    int PaneSelecionada = prin.tabControl1.SelectedIndex;

                    switch (PaneSelecionada)
                    {
                        case 4:
                            if (dgListaFornec.SelectedRows.Count > 0)
                            {
                                prin.atForCNPJ.ReadOnly = false;
                                prin.atForNome.ReadOnly = false;
                                prin.atForTelefone.ReadOnly = false;
                                prin.atForEndereco.ReadOnly = false;

                                prin.atForCNPJ.ForeColor = Color.Black;
                                prin.atForNome.ForeColor = Color.Black;
                                prin.atForTelefone.ForeColor = Color.Black;
                                prin.atForEndereco.ForeColor = Color.Black;

                                prin.button11.Enabled = false;


                                prin.atForCNPJ.Text = dgListaFornec.SelectedRows[0].Cells["CNPJ"].Value.ToString();
                                prin.atForNome.Text = dgListaFornec.SelectedRows[0].Cells["Nome"].Value.ToString();
                                prin.atForTelefone.Text = dgListaFornec.SelectedRows[0].Cells["Telefone"].Value.ToString();
                                prin.atForEndereco.Text = dgListaFornec.SelectedRows[0].Cells["Endereco"].Value.ToString();
                            }
                            break;
                        case 5:
                            if (dgListaFornec.SelectedRows.Count > 0)
                            {
                                prin.cadasPRODCNPJ.Text = dgListaFornec.SelectedRows[0].Cells["CNPJ"].Value.ToString();
                                prin.cadasPRODNome.Text = dgListaFornec.SelectedRows[0].Cells["Nome"].Value.ToString();
                                prin.cadasPRODTelefone.Text = dgListaFornec.SelectedRows[0].Cells["Telefone"].Value.ToString();
                                prin.cadasPRODEndereco.Text = dgListaFornec.SelectedRows[0].Cells["Endereco"].Value.ToString();
                            }
                            break;
                        default:
                            MessageBox.Show("Milagre do usuário!");
                            break;
                    }

                }
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            this.Close();
        }

        private void ConsultarForncedores_Load(object sender, EventArgs e)
        {
            PopulaGrid();
        }
    }
}
