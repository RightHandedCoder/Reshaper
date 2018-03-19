using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Metro
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
            try
            {
                Application.Run(new Form1());
            }
            catch (Exception ex) 
            {
                //new LogFile().SaveToLogFile(ex.ToString());
                Console.WriteLine(ex.ToString());
                Application.Restart();
                Environment.Exit(0);
            }
        }
    }
}
