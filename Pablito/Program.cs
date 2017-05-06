using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pablito
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
            Jarvis jarvis = new Jarvis();
            jarvis.Text += " MKV 0 ";
            jarvis.WindowState = FormWindowState.Maximized;
            Application.Run(jarvis);

        }
    }
}
