using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web;
using pim;
using System.Data.SqlClient;

namespace pim
{
    public partial class Principal : Form
    {
        string carg, nomeFUNC, IDFUNC;
        public Principal(string c, string email)
        {
            DataTable dt = new DataTable();
            Funcionario func = new Funcionario();
            InitializeComponent();
            carg = func.ValidarPerfilFuncionario(c);
            dt = func.lerIDNomeFuncionario(email);
            nomeFUNC = dt.Rows[0]["nome"].ToString();
            IDFUNC = dt.Rows[0]["IDUsuario"].ToString();
        }
        private void EscreveMsgUsuario(string msg)
        {
            usrMsg.Text = msg;
            usrMsg.BackColor = Color.LightYellow;
        }

        private void datagridviewConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnCadastrarUsu_Click(object sender, EventArgs e)
        {
            bool ret = false;
            Funcionario func = new Funcionario();
            Gerente grt = new Gerente();
            DataTable dt = new DataTable();
            string nome, id;

            usrMsg.BackColor = Color.LightGray;
            if (usrNome.Text == "Ex. Fulano de Tal")
            {
                MessageBox.Show("Por favor Digite o Campo Nome.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (usrSenha.Text == "123456")
            {
                MessageBox.Show("Por favor Digite o Campo Senha.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (usrTelefone.Text == "(99)9999-9999")
            {
                MessageBox.Show("Por favor Digite o Campo Telefone.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (usrEmail.Text == "FulanoDeTal@gmail.com")
            {
                MessageBox.Show("Por favor Digite o Campo E-mail.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (usrEndereco.Text == "R. Alameda")
            {
                MessageBox.Show("Por favor Digite o Campo Endereço.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (usrCargo.Text == "")
            {
                MessageBox.Show("Por favor selecione o Cargo.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (usrNome.Text.Trim().Length > 0) func.Nome = usrNome.Text;
                else { EscreveMsgUsuario("Nome Invalido"); return; }

                if (usrSenha.Text.Trim().Length > 0) func.Senha = usrSenha.Text;
                else { EscreveMsgUsuario("Senha Invalida"); return; }
                if (usrF.Checked)
                {
                    func.Sexo = "F";
                }
                else
                {
                    func.Sexo = "M";
                }
                func.Telefone = usrTelefone.Text;
                func.Email = usrEmail.Text;
                func.Endereco = usrEndereco.Text;
                func.Cargo = usrCargo.Text;
                func.DataNasc = usrDataNasc.Value;
                func.Status = "A";

                ret = grt.CadastrarFuncionario(func);

                if (ret == false)
                {
                    usrMsg.BackColor = Color.LightSalmon;
                    usrMsg.Text = "Cadastramento mau sucedido! Por favor Contactar o Admnistrador do Sistema.\r ERRO:" + func.MsgErro;
                }
                else
                {
                    Funcionario f = new Funcionario();
                    dt = f.lerIDNomeFuncionario(usrEmail.Text);
                    id = dt.Rows[0]["IDUsuario"].ToString();
                    nome = dt.Rows[0]["nome"].ToString();
                    usrMsg.BackColor = Color.LightGreen;
                    usrMsg.Text = "Cadastramento Bem sucedido";
                    MessageBox.Show("Senhor(a): " + nome + "\nseu novo ID: " + id, "Cadastrado", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    usrNome.Clear();
                    usrSenha.Clear();
                    usrTelefone.Clear();
                    usrEmail.Clear();
                    usrEndereco.Clear();
                    usrCargo.ResetText();
                    usrDataNasc.ResetText();
                    usrDataNasc.Text = DateTime.Now.ToShortTimeString();
                    usrF.Checked = false;
                    usrM.Checked = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Funcionario func = new Funcionario();
            Gerente gr = new Gerente();
            DataTable dt = new DataTable();
            atUsrMsg.BackColor = Color.LightGray;

            atUsrNome.Clear();
            atUsrSenha.Clear();
            atUsrTelefone.Clear();
            atUsrEmail.Clear();
            atUsrEndereco.Clear();
            atUsrCargo.ResetText();
            atUsrDataNasc.ResetText();
            atUsrF.Checked = false;
            atUsrM.Checked = false;
            atUsrA.Checked = false;
            atUsrI.Checked = false;

            dt = gr.ConsultarFuncionario(atUsrCod.Text);
            try
            {
                if (atUsrCod.Text == "")
                {
                    atUsrMsg.Text = "Por Favor Digite o ID!";
                    atUsrMsg.BackColor = Color.LightSalmon;

                    atUsrNome.Enabled = false;
                    atUsrSenha.Enabled = false;
                    atUsrTelefone.Enabled = false;
                    atUsrEmail.Enabled = false;
                    atUsrEndereco.Enabled = false;
                    atUsrCargo.Enabled = false;
                    atUsrDataNasc.Enabled = false;
                    atUsrF.Enabled = false;
                    atUsrM.Enabled = false;
                    atUsrA.Enabled = false;
                    atUsrI.Enabled = false;
                }
                else
                {
                    atUsrNome.Enabled = true;
                    atUsrSenha.Enabled = true;
                    atUsrTelefone.Enabled = true;
                    atUsrEmail.Enabled = true;
                    atUsrEndereco.Enabled = true;
                    atUsrCargo.Enabled = true;
                    atUsrDataNasc.Enabled = true;
                    atUsrF.Enabled = true;
                    atUsrM.Enabled = true;
                    atUsrA.Enabled = true;
                    atUsrI.Enabled = true;

                    atUsrNome.Text = dt.Rows[0]["nome"].ToString();
                    atUsrSenha.Text = dt.Rows[0]["senha"].ToString();
                    atUsrTelefone.Text = dt.Rows[0]["telefone"].ToString();
                    atUsrEmail.Text = dt.Rows[0]["email"].ToString();
                    atUsrEndereco.Text = dt.Rows[0]["endereco"].ToString();
                    atUsrCargo.Text = dt.Rows[0]["cargo"].ToString();
                    atUsrDataNasc.Text = dt.Rows[0]["datanasc"].ToString();
                    if (dt.Rows[0]["sexo"].ToString() == "F")
                    {
                        atUsrF.Checked = true;
                    }
                    else
                    {
                        atUsrM.Checked = true;
                    }
                    if (dt.Rows[0]["Status"].ToString() == "A")
                    {
                        atUsrA.Checked = true;
                    }
                    else
                    {
                        atUsrI.Checked = true;
                    }
                    atUsrMsg.BackColor = Color.LightGreen;
                    atUsrMsg.Text = "Consulta Bem sucedida";
                    atUsrCod.Enabled = false;
                    atUsrVerUsers.Enabled = false;
                    button5.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                atUsrCod.Enabled = false;
                atUsrMsg.Text = "Usuário não existe! Erro: " + ex.Message;
                atUsrMsg.BackColor = Color.LightSalmon;
                button5.Enabled = false;
                button7.Enabled = false;

                atUsrNome.Enabled = false;
                atUsrSenha.Enabled = false;
                atUsrTelefone.Enabled = false;
                atUsrEmail.Enabled = false;
                atUsrEndereco.Enabled = false;
                atUsrCargo.Enabled = false;
                atUsrDataNasc.Enabled = false;
                atUsrF.Enabled = false;
                atUsrM.Enabled = false;
                atUsrA.Enabled = false;
                atUsrI.Enabled = false;
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            usrNome.Clear();
            usrSenha.Clear();
            usrTelefone.Clear();
            usrEmail.Clear();
            usrEndereco.Clear();
            usrCargo.ResetText();
            usrDataNasc.ResetText();
            usrDataNasc.Text = DateTime.Now.ToShortTimeString();
            usrF.Checked = false;
            usrM.Checked = false;
            usrMsg.BackColor = Color.LightGray;
            usrMsg.Text = "";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            atUsrVerUsers.Enabled = true;
            atUsrCod.Enabled = true;
            atUsrCod.Clear();
            atUsrNome.Clear();
            atUsrSenha.Clear();
            atUsrTelefone.Clear();
            atUsrEmail.Clear();
            atUsrEndereco.Clear();
            atUsrCargo.ResetText();
            atUsrDataNasc.ResetText();
            atUsrDataNasc.Text = DateTime.Now.ToShortTimeString();
            atUsrF.Checked = false;
            atUsrM.Checked = false;
            atUsrA.Checked = false;
            atUsrI.Checked = false;
            atUsrMsg.BackColor = Color.LightGray;
            atUsrMsg.Text = "";
            button5.Enabled = true;

            atUsrNome.Enabled = false;
            atUsrSenha.Enabled = false;
            atUsrTelefone.Enabled = false;
            atUsrEmail.Enabled = false;
            atUsrEndereco.Enabled = false;
            atUsrCargo.Enabled = false;
            atUsrDataNasc.Enabled = false;
            atUsrF.Enabled = false;
            atUsrM.Enabled = false;
            atUsrA.Enabled = false;
            atUsrI.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {            
            vendaCodID.Text = IDFUNC.ToString();
            vendaNome.Text = nomeFUNC.ToString();
            lbNome.Text = "Seja Bem-vindo(a)  " + nomeFUNC;
            if (carg == "G")
            {
                tabPage1.Show();
                tabPage2.Show();
                tabPage3.Show();
                tabPage4.Show();
                tabPage5.Show();
                tabPage6.Show();
                tabPage7.Show();
            }
            else if (carg == "V")
            {
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage4);
                tabControl1.TabPages.Remove(tabPage5);
                tabControl1.TabPages.Remove(tabPage6);
                tabControl1.TabPages.Remove(tabPage7);
            }
            else if (carg == "E")
            {
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Remove(tabPage3);
                tabControl1.TabPages.Remove(tabPage6);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bool ret = false;
            Funcionario func = new Funcionario();
            Gerente grt = new Gerente();

            atUsrMsg.BackColor = Color.LightGray;
            if (atUsrCod.Text == "")
            {
                MessageBox.Show("Por favor Faça uma Consulta!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                func.ID = Convert.ToInt32(atUsrCod.Text);
                if (atUsrNome.Text.Trim().Length > 0) func.Nome = atUsrNome.Text;
                else { EscreveMsgUsuario("Nome Invalido"); return; }

                if (atUsrSenha.Text.Trim().Length > 0) func.Senha = atUsrSenha.Text;
                else { EscreveMsgUsuario("Senha Invalida"); return; }
                if (atUsrF.Checked)
                {
                    func.Sexo = "F";
                }
                else
                {
                    func.Sexo = "M";
                }
                func.Telefone = atUsrTelefone.Text;
                func.Email = atUsrEmail.Text;
                func.Endereco = atUsrEndereco.Text;
                func.Cargo = atUsrCargo.Text;
                func.DataNasc = atUsrDataNasc.Value;
                if (atUsrA.Checked)
                {
                    func.Status = "A";
                }
                else
                {
                    func.Status = "I";
                }

                ret = grt.AtualizarPorIdFuncionario(func);

                if (ret == false)
                {
                    atUsrMsg.BackColor = Color.LightSalmon;
                    atUsrMsg.Text = "Atualização mau sucedida! Por favor Contactar o Admnistrador do Sistema.\r ERRO:" + func.MsgErro;
                }
                else
                {
                    atUsrMsg.BackColor = Color.LightGreen;
                    atUsrMsg.Text = "Atualizado Com Sucesso!";


                    button5.Enabled = false;

                    atUsrNome.Enabled = false;
                    atUsrSenha.Enabled = false;
                    atUsrTelefone.Enabled = false;
                    atUsrEmail.Enabled = false;
                    atUsrEndereco.Enabled = false;
                    atUsrCargo.Enabled = false;
                    atUsrDataNasc.Enabled = false;
                    atUsrF.Enabled = false;
                    atUsrM.Enabled = false;
                    atUsrA.Enabled = false;
                    atUsrI.Enabled = false;

                    atUsrCod.Enabled = false;
                    atUsrCod.Clear();
                    atUsrNome.Clear();
                    atUsrSenha.Clear();
                    atUsrTelefone.Clear();
                    atUsrEmail.Clear();
                    atUsrEndereco.Clear();
                    atUsrCargo.ResetText();
                    atUsrDataNasc.ResetText();
                    atUsrDataNasc.Text = DateTime.Now.ToShortTimeString();
                    atUsrF.Checked = false;
                    atUsrM.Checked = false;
                    atUsrA.Checked = false;
                    atUsrI.Checked = false;
                }
            }
        }

        private void atUsrCod_MouseDown(object sender, MouseEventArgs e)
        {
            atUsrMsg.BackColor = Color.LightGray;
            atUsrMsg.Clear();
        }

        private void usrNome_Enter(object sender, EventArgs e)
        {
            if (usrNome.Text == "Ex. Fulano de Tal")
            {
                usrNome.Clear();
                usrNome.ForeColor = Color.Black;
            }
        }
        private void usrNome_Leave(object sender, EventArgs e)
        {
            if (usrNome.Text == "")
            {
                usrNome.Text = "Ex. Fulano de Tal";
                usrNome.ForeColor = Color.Gray;
            }
        }

        private void usrSenha_Enter(object sender, EventArgs e)
        {
            if (usrSenha.Text == "123456")
            {
                usrSenha.Clear();
                usrSenha.ForeColor = Color.Black;
            }
        }

        private void usrSenha_Leave(object sender, EventArgs e)
        {
            if (usrSenha.Text == "")
            {
                usrSenha.Text = "123456";
                usrSenha.ForeColor = Color.Gray;
            }
        }

        private void usrTelefone_Enter(object sender, EventArgs e)
        {
            if (usrTelefone.Text == "(99)9999-9999")
            {
                usrTelefone.Clear();
                usrTelefone.ForeColor = Color.Black;
            }
        }

        private void usrTelefone_Leave(object sender, EventArgs e)
        {
            if (usrTelefone.Text == "(  )    -")
            {
                usrTelefone.Text = "(99)9999-9999";
                usrTelefone.ForeColor = Color.Gray;
            }
        }

        private void usrEmail_Enter(object sender, EventArgs e)
        {
            if (usrEmail.Text == "FulanoDeTal@gmail.com")
            {
                usrEmail.Clear();
                usrEmail.ForeColor = Color.Black;
            }
        }

        private void usrEmail_Leave(object sender, EventArgs e)
        {
            if (usrEmail.Text == "")
            {
                usrEmail.Text = "FulanoDeTal@gmail.com";
                usrEmail.ForeColor = Color.Gray;
            }
        }

        private void usrEndereco_Enter(object sender, EventArgs e)
        {
            if (usrEndereco.Text == "R. Alameda")
            {
                usrEndereco.Clear();
                usrEndereco.ForeColor = Color.Black;
            }
        }

        private void usrEndereco_Leave(object sender, EventArgs e)
        {
            if (usrEndereco.Text == "")
            {
                usrEndereco.Text = "R. Alameda";
                usrEndereco.ForeColor = Color.Gray;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cadasForCNPJ_Enter(object sender, EventArgs e)
        {
            if (cadasForCNPJ.Text == "11.111.111/1111-11")
            {
                cadasForCNPJ.Clear();
                cadasForCNPJ.ForeColor = Color.Black;
            }
        }

        private void cadasForCNPJ_Leave(object sender, EventArgs e)
        {
            if (cadasForCNPJ.Text == "  .   .   /    -")
            {
                cadasForCNPJ.Text = "11.111.111/1111-11";
                cadasForCNPJ.ForeColor = Color.Gray;
            }
        }

        private void cadasForNome_Enter(object sender, EventArgs e)
        {
            if (cadasForNome.Text == "Ex. Fulano de Tal")
            {
                cadasForNome.Clear();
                cadasForNome.ForeColor = Color.Black;
            }
        }

        private void cadasForNome_Leave(object sender, EventArgs e)
        {
            if (cadasForNome.Text == "")
            {
                cadasForNome.Text = "Ex. Fulano de Tal";
                cadasForNome.ForeColor = Color.Gray;
            }
        }

        private void cadasForTelefone_Enter(object sender, EventArgs e)
        {
            if (cadasForTelefone.Text == "(99)9999-9999")
            {
                cadasForTelefone.Clear();
                cadasForTelefone.ForeColor = Color.Black;
            }
        }

        private void cadasForTelefone_Leave(object sender, EventArgs e)
        {
            if (cadasForTelefone.Text == "(  )    -")
            {
                cadasForTelefone.Text = "(99)9999-9999";
                cadasForTelefone.ForeColor = Color.Gray;
            }
        }

        private void cadasForEndereco_Enter(object sender, EventArgs e)
        {
            if (cadasForEndereco.Text == "R. Alameda")
            {
                cadasForEndereco.Clear();
                cadasForEndereco.ForeColor = Color.Black;
            }
        }

        private void cadasForEndereco_Leave(object sender, EventArgs e)
        {
            if (cadasForEndereco.Text == "")
            {
                cadasForEndereco.Text = "R. Alameda";
                cadasForEndereco.ForeColor = Color.Gray;
            }
        }

        private void cadasForLimpar_Click(object sender, EventArgs e)
        {
            cadasForCNPJ.Clear();
            cadasForNome.Clear();
            cadasForTelefone.Clear();
            cadasForEndereco.Clear();

            cadasForCadastrar.Enabled = true;

            cadasForCNPJ.Enabled = true;
            cadasForNome.Enabled = true;
            cadasForTelefone.Enabled = true;
            cadasForEndereco.Enabled = true;
            

            cadasForUsrMsg.BackColor = Color.LightGray;
            cadasForUsrMsg.Text = "";
        }

        private void btnCadastrarProd_Click(object sender, EventArgs e)
        {

        }

        private void atUsrCod_TextChanged(object sender, EventArgs e)
        {

        }

        private void usrNome_MouseDown(object sender, MouseEventArgs e)
        {
            usrMsg.BackColor = Color.LightGray;
            usrMsg.Text = "";
        }

        private void cadasForCadastrar_Click(object sender, EventArgs e)
        {
            bool ret = false;

            Produto prod = new Produto();
            Produto IDPRO = new Produto();
            DataTable dt = new DataTable();
            Gerente gr = new Gerente();

            if (cadasForCNPJ.Text == "11.111.111/1111-11")
            {
                MessageBox.Show("Por favor Digite o Campo CNPJ.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasForNome.Text == "Ex. Fulano de Tal")
            {
                MessageBox.Show("Por favor Digite o Campo Nome.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasForTelefone.Text == "(99)9999-9999")
            {
                MessageBox.Show("Por favor Digite o Campo Telefone.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasForEndereco.Text == "R. Alameda")
            {
                MessageBox.Show("Por favor Digite o Campo Endereço.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                prod.CNPJ = cadasForCNPJ.Text;
                prod.Nome = cadasForNome.Text;
                prod.Telefone = cadasForTelefone.Text;
                prod.Endereco = cadasForEndereco.Text;
                ret = gr.CadastrarFornecedor(prod);

                if (ret == false)
                {
                    cadasForUsrMsg.BackColor = Color.LightSalmon;
                    cadasForUsrMsg.Text = "Cadastramento mau sucedido! Por favor Contactar o Admnistrador do Sistema.\r ERRO:" + prod.MsgErro;
                }
                else
                {
                    cadasForCadastrar.Enabled = false;

                    cadasForCNPJ.Enabled = false;
                    cadasForNome.Enabled = false;
                    cadasForTelefone.Enabled = false;
                    cadasForEndereco.Enabled = false;

                    cadasForUsrMsg.BackColor = Color.LightGreen;
                    cadasForUsrMsg.Text = "Cadastramento Bem sucedido";
                }

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            bool ret = false, ret1 = false;

            Produto prod = new Produto();
            Produto IDPRO = new Produto();
            DataTable dt = new DataTable();
            Gerente gr = new Gerente();

            if (cadasPRODCategoria.Text == "")
            {
                MessageBox.Show("Por favor Digite o Campo Categoria.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasPRODMarca.Text == "")
            {
                MessageBox.Show("Por favor Digite o Campo Marca.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasPRODTamanho.Text == "")
            {
                MessageBox.Show("Por favor Digite o Campo Tamanho.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasPRODQuantidadeProd.Value == 0)
            {
                MessageBox.Show("Por favor Digite o Campo Quantidade do Produto.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasPRODValorCompraProd.Value == 0)
            {
                MessageBox.Show("Por favor Digite o Campo Valor de Compra de Produto.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasPRODValorVendaProd.Value == 0)
            {
                MessageBox.Show("Por favor Digite o Campo Valor de Venda.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasPRODQtdMax.Value == 0)
            {
                MessageBox.Show("Por favor Digite o Campo Quantidade Máxima do Estoque.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasPRODQtdMin.Value == 0)
            {
                MessageBox.Show("Por favor Digite o Campo Quantidade Mínima do Estoque.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cadasPRODCNPJ.Text == "  .   .   /    -")
            {
                MessageBox.Show("Por favor Faça uma busca do CNPJ do Fornecedor", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {

                prod.Categoria = cadasPRODCategoria.Text;
                prod.Marca = cadasPRODMarca.Text;
                prod.Tamanho = cadasPRODTamanho.Text;
                prod.QuantidadeProduto = Convert.ToInt32(cadasPRODQuantidadeProd.Value);
                prod.ValorCompraProd = Convert.ToInt32(cadasPRODValorCompraProd.Value);
                prod.ValorVendaProd = Convert.ToInt32(cadasPRODValorVendaProd.Value);
                prod.QuantidadeMaxEstoque = Convert.ToInt32(cadasPRODQtdMax.Value);
                prod.QuantidadeMinEstoque = Convert.ToInt32(cadasPRODQtdMin.Value);

                ret1 = gr.CadastrarFornecedorProduto(prod);//

                dt = gr.ConsultarIDProd(prod);
                int id = Convert.ToInt32(dt.Rows[0]["IDProd"].ToString());
                IDPRO.IDprod = id;
                IDPRO.CNPJ = cadasPRODCNPJ.Text;
                ret = gr.CadastrarForn_IDProd(IDPRO);

                if (ret == false || ret1 == false)
                {
                    cadasPRODUsrMsg.BackColor = Color.LightSalmon;
                    cadasPRODUsrMsg.Text = "Cadastramento mau sucedido! Por favor Contactar o Admnistrador do Sistema.\r ERRO:" + prod.MsgErro + IDPRO.MsgErro;
                }
                else
                {
                    cadasPRODCadastrar.Enabled = false;

                    cadasPRODCategoria.Enabled = false;
                    cadasPRODMarca.Enabled = false;
                    cadasPRODTamanho.Enabled = false;
                    cadasPRODQuantidadeProd.Enabled = false;
                    cadasPRODValorCompraProd.Enabled = false;
                    cadasPRODValorVendaProd.Enabled = false;
                    cadasPRODQtdMax.Enabled = false;
                    cadasPRODQtdMin.Enabled = false;

                    cadasPRODUsrMsg.BackColor = Color.LightGreen;
                    cadasPRODUsrMsg.Text = "Cadastramento Bem sucedido";
                }
            }
        }

        private void cadasPRODLimpar_Click(object sender, EventArgs e)
        {
            cadasPRODCategoria.Text = "";
            cadasPRODMarca.Text = "";
            cadasPRODTamanho.Text = "";
            cadasPRODQuantidadeProd.Value = 0;
            cadasPRODValorCompraProd.Value = 0;
            cadasPRODValorVendaProd.Value = 0;
            cadasPRODQtdMax.Value = 0;
            cadasPRODQtdMin.Value = 0;

            cadasPRODCadastrar.Enabled = true;

            cadasPRODCategoria.Enabled = true;
            cadasPRODMarca.Enabled = true;
            cadasPRODTamanho.Enabled = true;
            cadasPRODQuantidadeProd.Enabled = true;
            cadasPRODValorCompraProd.Enabled = true;
            cadasPRODValorVendaProd.Enabled = true;
            cadasPRODQtdMax.Enabled = true;
            cadasPRODQtdMin.Enabled = true;

            cadasPRODCNPJ.Clear();
            cadasPRODNome.Clear();
            cadasPRODTelefone.Clear();
            cadasPRODEndereco.Clear();

            cadasPRODUsrMsg.BackColor = Color.LightGray;
            cadasPRODUsrMsg.Text = "";
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            ConsultarForncedores frmConsultarFornecedores = new ConsultarForncedores();
            frmConsultarFornecedores.prin = this;
            frmConsultarFornecedores.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            VerUsuarios verUser = new VerUsuarios();
            verUser.prin = this;
            verUser.Show();
        }

        private void btnConsultarProduto_Click(object sender, EventArgs e)
        {
            ConsultarProdutos consultarPROD = new ConsultarProdutos();
            consultarPROD.prin = this;
            consultarPROD.Show();
            vendaVdaQtdPROD.Enabled = true;
        }

        private void vendaVdaQtdPROD_Click(object sender, EventArgs e)
        {
            int a = 0, c = 0,b = 0;
            a = Convert.ToInt32(vendaCompraPROD.Text.ToString());
            c = Convert.ToInt32(vendaVdaQtdPROD.Value.ToString());
            b = c * a;
            vendaVdaQtdPROD.Maximum = Convert.ToInt32(vendaQtdPRODEstoque.Text);
            if (vendaVdaQtdPROD.Value == Convert.ToInt32(vendaQtdPRODEstoque.Text))
            {
                vendaVlTotal.Text = b.ToString();
                MessageBox.Show("Quantidade de Produtos Excedida.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                vendaVlTotal.Text = b.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int IDVenda;
            string id;
            bool ret = false,ret1 = false,ret2 = false;
            DataTable dt,dt1,dt2 = new DataTable();
            DataSet ds = new DataSet();
            Funcionario func = new Funcionario();
            Gerente gr = new Gerente();
            Vendedor vend = new Vendedor();
            Produto prod = new Produto();

            dt = func.ConsultaIDProd_Forn(Convert.ToInt32(vendaIDPROD.Text));
            id = dt.Rows[0]["IDForn_prod"].ToString();

            vend.IDuser = Convert.ToInt32(vendaCodID.Text);
            vend.IDForn_Prod = Convert.ToInt32(id);
            vend.DataVenda= vendaDataVenda.Value;
            vend.TotalVenda = Convert.ToInt32(vendaVlTotal.Value);

             
            dt2 = gr.LerTodosProdutos();
            object sumObject;
            sumObject = dt2.Compute("Sum(QuantidadeProduto)", "");

            ret = gr.CadastrarVenda(vend);            
            dt1 = func.ConsultaIDVenda(vend);
            IDVenda = Convert.ToInt32( dt1.Rows[0]["IDVenda"].ToString());

            ret1 = gr.CadastrarRelatorio(IDVenda, Convert.ToInt32(sumObject.ToString()), Convert.ToInt32(vendaVdaQtdPROD.Value.ToString()), Convert.ToInt32(vendaVlTotal.Value));


            prod.IDprod = Convert.ToInt32(vendaIDPROD.Text);
            prod.QuantidadeProduto = Convert.ToInt32(vendaVdaQtdPROD.Value.ToString());
            ret2 = gr.AtualizarProd(prod);
            if (ret == false || ret1 == false || ret2 == false)
            {
                vendaMsg.BackColor = Color.LightSalmon;
                vendaMsg.Text = "Venda mal sucedida! Por favor Contactar o Admnistrador do Sistema.\r ERRO:";
            }
            else 
            {

                vendaMsg.BackColor = Color.LightGreen;
                vendaMsg.Text = "Venda Efetuada Com Sucesso";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            DataTable dt = new DataTable();
            Gerente gr = new Gerente();

            dt = gr.LerTodosRelatorio();
            dgRelatorio.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            vendaIDPROD.Text = "";
            vendaCategoria.Text = "";
            vendaMarca.Text = "";
            vendaTamanho.Text = "";
            vendaQtdPRODEstoque.Text ="";
            vendaCompraPROD.Value = 0;
            vendaVdaQtdPROD.Value = 0;
            vendaVlTotal.Value = 0;
            vendaVdaQtdPROD.Enabled = false;

            vendaMsg.BackColor = Color.LightGray;
            vendaMsg.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            atForCNPJ.Clear();
            atForNome.Clear();
            atForTelefone.Clear();
            atForEndereco.Clear();
            button11.Enabled = true;

            atForCNPJ.ReadOnly = true;
            atForNome.ReadOnly = true;
            atForTelefone.ReadOnly = true;
            atForEndereco.ReadOnly = true;
            
            atForUsrMsg.BackColor = Color.LightGray;
            atForUsrMsg.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {            
            ConsultarForncedores frmConsultarFornecedores = new ConsultarForncedores();
            frmConsultarFornecedores.prin = this;
            frmConsultarFornecedores.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool ret = false;
            Fornecedor forn = new Fornecedor();
            Gerente gr = new Gerente();

            if (atForCNPJ.Text == "  .   .   /    -")
            {
                MessageBox.Show("Por favor Faça uma Consulta!", "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                forn.CNPJ = atForCNPJ.Text;
                forn.Nome = atForNome.Text;
                forn.Telefone = atForTelefone.Text;
                forn.Endereco = atForEndereco.Text;

                ret = gr.AtualizarFornecedor(forn);

                if (ret == false)
                {
                    atForUsrMsg.BackColor = Color.LightSalmon;
                    atForUsrMsg.Text = "Atualização mau sucedida! Por favor Contactar o Admnistrador do Sistema.\r ERRO:" + forn.MsgErro;
                }
                else
                {
                    atForUsrMsg.BackColor = Color.LightGreen;
                    atForUsrMsg.Text = "Atualizado Com Sucesso!";
                    button3.Enabled = false;
                }
            }
    
        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:3137/Relatorio.aspx");
        }
    }
}
