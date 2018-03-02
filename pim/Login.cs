using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim
{
    public partial class Login : Form
    {
        public string cargo,email;
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Funcionario func = new Funcionario();
            Gerente gr = new Gerente();
            DataTable dt = new DataTable();
            dt = gr.ConsultarFuncionario(LgCodUsr.Text);

            try
            {
                if (LgCodUsr.Text == "" && LgSenhaUsr.Text == "")
                {
                    MessageBox.Show("Por Favor Digite o ID e a Senha.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                    if (LgCodUsr.Text == "")
                    {
                        MessageBox.Show("Por Favor Digite o ID", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        if (LgSenhaUsr.Text == "")
                        {
                            MessageBox.Show("Por Favor Digite a Senha.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (LgCodUsr.Text == dt.Rows[0]["IDUsuario"].ToString() && LgSenhaUsr.Text == dt.Rows[0]["senha"].ToString())
                            {
                                DialogResult = DialogResult.OK;
                                cargo = dt.Rows[0]["cargo"].ToString();
                                email = dt.Rows[0]["email"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("ID ou Senha incorretos", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }
                        }
            }
            catch
            {
                MessageBox.Show("ID Não existe.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LgCodUsr.Clear();
            LgSenhaUsr.Clear();
        }

        private void LgSenhaUsr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
