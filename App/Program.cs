using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
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
            bool ketthuc = false;
            while (!ketthuc)
            {
                welcome wl = new welcome();
                Application.Run(wl);
                if (wl.exit)
                {
                    ketthuc = true;
                }
                else
                {
                    ketthuc = false;
                }
            }
            
        }
    }
}
