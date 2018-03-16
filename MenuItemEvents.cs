using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Metro
{
    abstract class MenuItemEvents
    {
        private static RichTextBox editor;
        private static string filepath;

        public static void Init(RichTextBox e)
        {
            editor = e;  
        }

        public static void ClearEditor()
        {
            editor.Clear();
        }

        public static void OpenFile()
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                filepath = openfile.FileName;
            }
            editor.LoadFile(filepath, RichTextBoxStreamType.PlainText);
        }

        public static void SaveFile()
        {
            try
            {
                editor.SaveFile(filepath, RichTextBoxStreamType.PlainText);
            }
            catch (Exception)
            {
                SaveFileAs();
            }
            
        }

        public static void SaveFileAs()
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(savefile.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(editor.Text);
                    filepath = savefile.FileName;
                }
                editor.SaveFile(filepath, RichTextBoxStreamType.PlainText);
            }
            else
            {
                return;
            }
        }

        public static void Run()
        {
            Process process = new Process();
            string s = filepath;
            int x = s.LastIndexOf('\\');
            s = s.Substring(0, x);
            string command = "cd " + s;

            StreamWriter sw = new StreamWriter("LastSuccessfulRun.bat");
            sw.WriteLine("@echo off");
            sw.WriteLine(command);
            command = "csc " + filepath;
            sw.WriteLine(command);
            s = filepath;
            s = s.Remove(s.Length - 3);
            sw.WriteLine(s);
            sw.WriteLine("@pause");
            sw.Close();

            Process.Start("LastSuccessfulRun.bat");
        }

        public static void About()
        {

        }
    }
}
