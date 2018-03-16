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
        List<Line> lineList = new List<Line>();
        List<Line> errorLines = new List<Line>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initializer.Init(NrichTextBox, ErrorLog, suggestionBox);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.ClearEditor();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.OpenFile();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.SaveFile();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //dont need
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Cut();
        }

        //dont need
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Copy();
        }

        //dont need
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Paste();
        }

        //dont need
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Undo();
        }

        //dont need
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Redo();
        }

        //dont need
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

        //dont need
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

        //dont need
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
            MenuItemEvents.About();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.Run();
        }
      
        private void NrichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            KeyEventsHandler.EditorKeyHandler(e.KeyCode);
            if (e.KeyCode==Keys.Enter)
            {
                if (BackgroundErrorTracer.IsBusy)
                {
                    BackgroundErrorTracer.CancelAsync();
                }
                else
                    BackgroundErrorTracer.RunWorkerAsync();
            } 
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
            if (KeyEventsHandler.controlKeyPressed) {
                KeyEventsHandler.EditorMulitpleKeyPressHandler(e.KeyCode);
            }

            KeyEventsHandler.controlKeyPressed = e.Modifiers == Keys.Control;
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

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.SaveFileAs();
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
