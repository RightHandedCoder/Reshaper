using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NotePad_Metro.Refactor;
using NotePad_Metro.Logical;
using System.Drawing;
using System.IO;
using System.Diagnostics;

namespace NotePad_Metro
{
    public partial class Form1 : Form
    {
        Test t;
        
        string[] arr = new string[1000];
        List<Line> lineList = new List<Line>();
        List<Line> errorLines = new List<Line>();
        string filepath;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new Test(NrichTextBox);
            Utility.Init(NrichTextBox, ErrorLog, suggestionBox);
            KeyEventsHandler.Init(NrichTextBox, ErrorLog, suggestionBox);
            TokenGenerator.InitBox(NrichTextBox);
            Highlighter.Init(NrichTextBox);
            SuggestionProvider.InitSuggestionProvider(new List<string>(), suggestionBox, NrichTextBox);
            Coloring.InitColoring(NrichTextBox);
            Helper.Init();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                filepath = openfile.FileName;
            }
            NrichTextBox.LoadFile(filepath, RichTextBoxStreamType.PlainText);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NrichTextBox.SaveFile(filepath, RichTextBoxStreamType.PlainText);
            }
            catch (Exception ex)
            {
                saveAsToolStripMenuItem_Click(sender, e);
            }

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Redo();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog ft = new FontDialog();
            ft.Font = NrichTextBox.SelectionFont;
            if (ft.ShowDialog() == DialogResult.OK)
            {
                NrichTextBox.SelectionFont = ft.Font;
            }
            else { }
            
        }

        private void backgroudColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                NrichTextBox.BackColor = cr.Color;

            }
            else
            { }
        }

        private void foreColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cr = new ColorDialog();
            if (cr.ShowDialog() == DialogResult.OK)
            {
                NrichTextBox.ForeColor = cr.Color;

            }
            else
            { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
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
      
        private void NrichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (BackgroundErrorTracer.IsBusy)
                {
                    BackgroundErrorTracer.CancelAsync();
                }
                else
                    BackgroundErrorTracer.RunWorkerAsync();
            }
            KeyEventsHandler.EditorKeyHandler(e.KeyCode);
        }

        private void generateDocumentationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fIXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Line line in errorLines)
            {
                if(line.type == "variable")
                {
                    Refactorer.FixVariableDecleration(lineList, line);
                }

                else if(line.type == "method")
                {
                    Refactorer.FixMethodDecleration(lineList, line);
                }

                else if (line.type == "class")
                {
                    Refactorer.FixClassDecleration(lineList, line);
                }
            }

            NrichTextBox.Clear();
            foreach(Line line in lineList)
            {
                NrichTextBox.AppendText(line.text+"\n");
            }
        }

        private void NrichTextBox_TextChanged(object sender, EventArgs e)
        {
            Coloring.DoColoring();
        }

        private void NrichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                string s = "";
                string[] lines = NrichTextBox.SelectedText.Split(new[] { '\n' }
                                          , StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    if (line.StartsWith("//"))
                    {
                        s += line.TrimStart('/') + "\n";
                    }
                    else
                    {
                        s += "//" + line + "\n";
                    }
                }
                s = s.Remove(s.Length - 1);
                NrichTextBox.SelectedText = NrichTextBox.SelectedText.Replace(NrichTextBox.SelectedText, s);
            }
            if(e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                saveToolStripMenuItem_Click(sender, e);
            }
            if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
            {
                openToolStripMenuItem_Click(sender, e);
            }

            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                runToolStripMenuItem_Click(sender, e);
            }
        }

        private void NrichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                suggestionBox.Items.Clear();
                Utility.AddToTemp(e.KeyChar);
                SuggestionProvider.GetSuggestion(Utility.GetTemp());
                string bracket = Helper.Check(e.KeyChar);
                if (bracket != "")
                {
                    NrichTextBox.Text.Remove(NrichTextBox.Text.Length - 2, 1);
                    NrichTextBox.AppendText(bracket);
                    e.Handled = true;
                }

            }

            catch (Exception) { }
        }

        private void suggestionBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyEventsHandler.SuggestionKeyHandler(e.KeyCode);
        }

        public void SuggestionPosition()
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(savefile.FileName, FileMode.CreateNew))
                using (System.IO.StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(NrichTextBox.Text);
                    filepath = savefile.FileName;
                }
            }
            NrichTextBox.SaveFile(filepath, RichTextBoxStreamType.PlainText);
        }

        private void BackgroundErrorTracer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try {
                foreach (Line line in LineCollection.lineList)
                {
                    if (line.type == "variable")
                    {
                        if (!Refactorer.CheckVariableDecleration(line.text))
                        {
                            Line errorLine = new Line();
                            errorLine.lineNumber = line.lineNumber;
                            errorLine.text = "// variable decleration error!";
                            errorLine.type = "variable";
                            if (!errorLines.Contains(errorLine))
                            {
                                errorLines.Add(errorLine);
                            }
                        }
                    }

                    else if (line.type == "method")
                    {
                        if (!Refactorer.CheckMethodDecleration(line.text))
                        {
                            Line errorLine = new Line();
                            errorLine.lineNumber = line.lineNumber;
                            errorLine.text = "// method decleration error!";
                            errorLine.type = "method";
                            if (!errorLines.Contains(errorLine))
                            {
                                errorLines.Add(errorLine);
                            }
                        }
                    }

                    else if (line.type == "class")
                    {
                        if (!Refactorer.CheckClassDecleration(line.text))
                        {
                            Line errorLine = new Line();
                            errorLine.lineNumber = line.lineNumber;
                            errorLine.text = "// Class decleration error!";
                            errorLine.type = "class";
                            if (!errorLines.Contains(errorLine))
                            {
                                errorLines.Add(errorLine);
                            }
                        }
                    }
                    else
                    {
                        Line errorLine = new Line();
                        errorLine.lineNumber = line.lineNumber;
                        errorLine.text = "// Unidentified Line type";
                        errorLine.type = "Unidentified";
                        if (!errorLines.Contains(errorLine))
                        {
                            errorLines.Add(errorLine);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BackgroundErrorTracer_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

            if (ErrorLog.Text != null)
            {
                ErrorLog.Text = null;
            }
            foreach (Line line in errorLines)
            {
                ErrorLog.AppendText(line.lineNumber + " -> " + line.text + "\r\n");
            }
        }
    }
}
