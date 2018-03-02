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
    public partial class VerUsuarios : Form
    {
        public Principal prin { get; set; }
        public VerUsuarios()
        {
            InitializeComponent();
        }
        public DataTable ConsultaTodosUsers()
        {
            DataTable dt = null;

            try
            {
                Gerente gr = new Gerente();
                dt = gr.ConsultaTodosUsers();
            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            return dt;
        }


        public void PopulaGrid()
        {
            dgListaUsers.DataSource = ConsultaTodosUsers();

        }

        private void VerUsuarios_Load(object sender, EventArgs e)
        {
            PopulaGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (prin != null)
                {
                    if (dgListaUsers.SelectedRows.Count > 0)
                    {                        
                        prin.atUsrCod.Text = dgListaUsers.SelectedRows[0].Cells["IDUsuario"].Value.ToString();
                        prin.button5.PerformClick();
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
