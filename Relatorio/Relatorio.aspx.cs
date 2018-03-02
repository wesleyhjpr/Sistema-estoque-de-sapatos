using pim;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Relatorio
{
    public partial class Relatorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable ds = new DataTable();
            Gerente db = null;
            Relatorio rd = new Relatorio();
            try
            {
                
                db = new Gerente();
                ds = db.LerTodosRelatorio();
                dgListaClientes.DataSource = ds;
                dgListaClientes.DataBind();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }
        }
    }
}