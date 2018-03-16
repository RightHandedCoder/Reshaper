using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro
{
    class LogFile
    {
        private string fileName;
        private static string logDirectory;

        public LogFile()
        {
            this.fileName = "Log-" + DateTime.Now.ToString().Replace(':','.') + ".txt";
        }

        public void SaveToLogFile(string msg)
        {
            logDirectory = @"C:\Users\Public\Documents\" + this.fileName;
            using (StreamWriter file = new StreamWriter(logDirectory))
            {
                file.WriteLine(msg);
            }
        }
    }
}
