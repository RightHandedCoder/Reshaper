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
            openfile.Filter = ("C# Source File |*.cs");

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                filepath = openfile.FileName;
                editor.LoadFile(filepath, RichTextBoxStreamType.PlainText);
            }
            
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
            savefile.Filter = ("C# Source File |*.cs");
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
            string s = GetFilePathIfSaved();
            if (s != null)
            {
                Process process = new Process();

                string batFileLocation = GetFilePath(s) + @"LastSuccessfulRun.bat";
                StreamWriter sw = new StreamWriter(batFileLocation);
                sw.WriteLine("@echo off");
                string fileFolder = filepath.Remove(filepath.LastIndexOf('\\'));
                string command = "cd " + fileFolder;
                sw.WriteLine(command);
                command = "csc " + MakePathForBat(GetFileNameWithExt(filepath));
                sw.WriteLine(command);
                command = MakePathForBat(GetFileName(filepath));
                sw.WriteLine("cls");
                sw.WriteLine(command);
                sw.WriteLine("@pause");
                sw.Close();

                Process.Start(batFileLocation);
            }

            else
            {
                MessageBox.Show("You need to save the file to run");
            }
            
        }

        public static void About()
        {

        }

        private static string GetFilePathIfSaved()
        {
            return filepath;
        }

        private static string GetFilePath(string path)
        {
            string filename = GetFileNameWithExt(path);
            int indexOfFileName = path.LastIndexOf(filename);
            return path.Remove(indexOfFileName);
        }

        private static string GetFileNameWithExt(string path)
        {
            int indexOfLastDash = path.LastIndexOf(@"\");
            return path.Substring(indexOfLastDash + 1);
        }

        private static string GetFileName(string path)
        {
            string ext = ".cs";
            string withExt = GetFileNameWithExt(path);
            int indexOfExt = withExt.IndexOf(ext);
            return withExt.Remove(indexOfExt);
        }

        private static string MakePathForBat(string path)
        {
            return "\"" + path + "\""; 
        }
    }
}
