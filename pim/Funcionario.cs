using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace pim
{
    public class Funcionario : SGBD
    {
        public int ID{ get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public string Cargo { get; set; }
        public DateTime DataNasc { get; set; }
        public string Status { get; set; }


        public DataTable lerIDNomeFuncionario(string email)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = "exec sp_ConsultarIDNome " + "'" + email + "'";
                this.comando.CommandType = System.Data.CommandType.StoredProcedure;
                da = new SqlDataAdapter(this.comando.CommandText, this.coenxao);
                da.Fill(ds);


                if (ds != null && ds.Tables.Count > 0)
                {

                    dt = ds.Tables[0];

                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }

            return dt;
        }
        public string ValidarPerfilFuncionario(string cargo) 
        {
            string carg = null;
            if(cargo == "Gerente"){
                carg = "G";
            }else if(cargo == "Vendedor"){
                carg = "V";
            }
            else if (cargo == "Estoquista")
            {
                carg = "E";
            }
            return carg;
        }
        protected string ConsultarRelatorioFaturamento()
        {
            return "";
        }
        protected void NovaVenda()
        {

        }
        protected string ExcluirProduto()
        {
            return "";
        }
        protected void CadastrarProduto()
        {

        }
        protected string ConsultarVenda()
        {
            return "";
        }
        protected void AlterarProduto()
        {

        }
        public DataTable ConsultaIDProd_Forn(int i)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = "exec sp_ConsultarIDForn_Prod" + "'" + i + "'";
                this.comando.CommandType = System.Data.CommandType.StoredProcedure;
                da = new SqlDataAdapter(this.comando.CommandText, this.coenxao);
                da.Fill(ds);


                if (ds != null && ds.Tables.Count > 0)
                {

                    dt = ds.Tables[0];
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }

            return dt;
        }
        public DataTable ConsultaIDVenda(Vendedor vend)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = "exec sp_ConsultarIDVenda" + "'" +
                                                                       vend.IDuser.ToString()
                                                                     + "'," + "'"
                                                                     + vend.IDForn_Prod.ToString()
                                                                     + "'," + "'"
                                                                     + vend.DataVenda.Year.ToString() + "/" + vend.DataVenda.Month.ToString() + "/" + vend.DataVenda.Day.ToString()
                                                                     + "'," + "'"
                                                                     + vend.TotalVenda
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.StoredProcedure;
                da = new SqlDataAdapter(this.comando.CommandText, this.coenxao);
                da.Fill(ds);


                if (ds != null && ds.Tables.Count > 0)
                {

                    dt = ds.Tables[0];
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }

            return dt;
        }
        public DataTable ConsultaTodosProdutos()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = "exec sp_ConsultaTodosProdutos";
                this.comando.CommandType = System.Data.CommandType.StoredProcedure;
                da = new SqlDataAdapter(this.comando.CommandText, this.coenxao);
                da.Fill(ds);


                if (ds != null && ds.Tables.Count > 0)
                {

                    dt = ds.Tables[0];
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }

            return dt;
        }

    }
}
