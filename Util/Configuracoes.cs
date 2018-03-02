using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Util
{
    public class Configuracoes
    {
        /// <summary>
        /// Metodo que le da sessão string de conexao um ConnectionStrings
        /// em função da chave(Key) fornecida 
        /// </summary>
        /// <param name="Key">Seleciona a string deconexao desejada pela aplicação</param>
        /// <returns></returns>
        public string LeStringConexao(string Key)
        {
            string ret = string.Empty;

            ret = ConfigurationManager.ConnectionStrings[Key].ConnectionString;

            return ret;
        }
    }
}
