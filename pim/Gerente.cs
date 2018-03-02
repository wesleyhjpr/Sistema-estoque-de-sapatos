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
    public class Gerente : Funcionario
    {
        public bool CadastrarFuncionario(Funcionario func)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_CadastrarUser " + "'" +
                                                                     func.Nome.ToString()
                                                                     + "'," + "'"
                                                                     + func.Senha.ToString()
                                                                     + "'," + "'"
                                                                     + func.Sexo.ToString()
                                                                     + "'," + "'"
                                                                     + func.Telefone.ToString()
                                                                     + "'," + "'"
                                                                     + func.Email.ToString()
                                                                     + "'," + "'"
                                                                     + func.Endereco.ToString()
                                                                     + "'," + "'"
                                                                     + func.Cargo.ToString()
                                                                     + "'," + "'"
                                                                     + func.DataNasc.Year.ToString() + "/" + func.DataNasc.Month.ToString() + "/" + func.DataNasc.Day.ToString()
                                                                     + "'," + "'"
                                                                     + func.Status.ToString()
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                func.MsgErro = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }
        public DataTable ConsultarFuncionario(string id)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = "exec sp_ConsultarUser " + "" + id + "";
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
        public bool AtualizarPorIdFuncionario(Funcionario func)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_AtualizarUser "  + "'" 
                                                                     + func.ID.ToString()
                                                                     + "'," + "'"
                                                                     + func.Nome.ToString()
                                                                     + "'," + "'"
                                                                     + func.Senha.ToString()
                                                                     + "'," + "'"
                                                                     + func.Sexo.ToString()
                                                                     + "'," + "'"
                                                                     + func.Telefone.ToString()
                                                                     + "'," + "'"
                                                                     + func.Email.ToString()
                                                                     + "'," + "'"
                                                                     + func.Endereco.ToString()
                                                                     + "'," + "'"
                                                                     + func.Cargo.ToString()
                                                                     + "'," + "'"
                                                                     + func.DataNasc.Year.ToString() + "/" + func.DataNasc.Month.ToString() + "/" + func.DataNasc.Day.ToString()
                                                                     + "'," + "'"
                                                                     + func.Status.ToString()
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                func.MsgErro = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }
        public bool AtualizarFornecedor(Fornecedor forn)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_AtualizarFornecedor " + "'"
                                                                     + forn.CNPJ.ToString()
                                                                     + "'," + "'"
                                                                     + forn.Nome.ToString()
                                                                     + "'," + "'"
                                                                     + forn.Telefone.ToString()
                                                                     + "'," + "'"
                                                                     + forn.Endereco.ToString()
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                forn.MsgErro = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }

        public bool CadastrarFornecedor(Produto prod)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_CadastrarFornecedor " + "'" +
                                                                       prod.CNPJ.ToString()
                                                                     + "'," + "'"
                                                                     + prod.Nome.ToString()
                                                                     + "'," + "'"
                                                                     + prod.Telefone.ToString()
                                                                     + "'," + "'"
                                                                     + prod.Endereco.ToString()
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                prod.MsgErro = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }

        public bool CadastrarFornecedorProduto(Produto  prod)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_CadastrarFornecedorProduto " + "'" +
                                                                       prod.Categoria.ToString()
                                                                     + "'," + "'"
                                                                     + prod.Marca.ToString()
                                                                     + "'," + "'"
                                                                     + prod.Tamanho
                                                                     + "'," + "'"
                                                                     + prod.QuantidadeProduto
                                                                     + "'," + "'"
                                                                     + prod.ValorCompraProd
                                                                     + "'," + "'"
                                                                     + prod.ValorVendaProd
                                                                     + "'," + "'"
                                                                     + prod.QuantidadeMaxEstoque
                                                                     + "'," + "'"
                                                                     + prod.QuantidadeMinEstoque
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                prod.MsgErro = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }
        
        public DataTable ConsultarIDProd(Produto prod)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = "exec sp_ConsultarIDProd " + "'" +
                                                                       prod.Categoria.ToString()
                                                                     + "'," + "'"
                                                                     + prod.Marca.ToString()
                                                                     + "'," + "'"
                                                                     + prod.Tamanho
                                                                     + "'," + "'"
                                                                     + prod.QuantidadeProduto
                                                                     + "'," + "'"
                                                                     + prod.ValorCompraProd
                                                                     + "'," + "'"
                                                                     + prod.ValorVendaProd
                                                                     + "'," + "'"
                                                                     + prod.QuantidadeMaxEstoque
                                                                     + "'," + "'"
                                                                     + prod.QuantidadeMinEstoque
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
        public bool CadastrarForn_IDProd(Produto prod)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_CadastrarFornIDProd " + "'" +
                                                                       prod.CNPJ.ToString()
                                                                     + "'," + "'"
                                                                     + prod.IDprod
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                prod.MsgErro = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }
        public DataTable LerTodosFornecedores()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = "exec sp_ConsultaTodosFornecedores";
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
        public DataTable ConsultaTodosUsers()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = " exec sp_ConsultarTodosUsers";
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
        public bool CadastrarVenda(Vendedor vend)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_CadastrarVenda " + "'" +
                                                                       vend.IDuser.ToString()
                                                                     + "'," + "'"
                                                                     + vend.IDForn_Prod.ToString()
                                                                     + "'," + "'"
                                                                     + vend.DataVenda.Year.ToString() + "/" + vend.DataVenda.Month.ToString() + "/" + vend.DataVenda.Day.ToString()
                                                                     + "'," + "'"
                                                                     + vend.TotalVenda
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                string err = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }
        public bool AtualizarProd(Produto prod)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_AtualizarProduto " + "'" +
                                                                       Convert.ToInt32(prod.IDprod.ToString())
                                                                     + "'," + "'"
                                                                     + prod.QuantidadeProduto
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                string err = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }
        public bool CadastrarRelatorio(int idvenda,int qtdProdComprados, int qtdProdVendidos, float totalVenda)
        {
            bool ret = false;
            try
            {
                this.comando.CommandText = "exec sp_CadastrarRelatorio " + "'" +
                                                                       idvenda
                                                                     + "'," + "'"
                                                                     + qtdProdComprados
                                                                     + "'," + "'"
                                                                     + qtdProdVendidos
                                                                     + "'," + "'"
                                                                     + totalVenda
                                                                     + "'";
                this.comando.CommandType = System.Data.CommandType.Text;
                this.coenxao.Open();
                this.comando.ExecuteNonQuery();
                ret = true;
            }
            catch (SqlException ex)
            {
                string err = ex.Message;
            }
            finally
            {
                this.coenxao.Close();
            }
            return ret;
        }
        public DataTable LerTodosRelatorio()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            SqlDataAdapter da = null;

            try
            {
                this.comando.CommandText = "exec sp_ConsultarRelatorio";
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
        public DataTable LerTodosProdutos()
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
