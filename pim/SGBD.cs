using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace pim
{
    public class SGBD
    {
        public string NomeBanco { get; set; }
        public string MsgErro { get; set; }
        public string strConexao { get; set; }
        public Configuracoes config = new Configuracoes();
        public SqlConnection coenxao = new SqlConnection();
        public SqlCommand comando = new SqlCommand();

        public SGBD()
        {
            try
            {
                this.NomeBanco = "LojaSapatos";
                this.strConexao = this.config.LeStringConexao(NomeBanco);
                this.coenxao.ConnectionString = strConexao;
                this.comando.Connection = coenxao;
                
                
            }
            catch (Exception ex)
            {
                MsgErro = ex.Message;
                strConexao = "";
            }
        }
    }
}
