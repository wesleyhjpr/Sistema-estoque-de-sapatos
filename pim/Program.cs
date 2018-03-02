using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pim
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            start:
            Login lg = new Login();
            if (lg.ShowDialog() == DialogResult.OK)
            {
                Principal frm = new Principal(lg.cargo,lg.email);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    goto start;
                }
            }
        }
    }
}
