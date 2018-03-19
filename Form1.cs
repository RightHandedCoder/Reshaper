using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NotePad_Metro.Refactor;
using NotePad_Metro.Logical;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

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
            LineNumberTextBox.Font = NrichTextBox.Font;
            NrichTextBox.Select();
            AddLineNumbers();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.ClearEditor();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Coloring.counter = 0;
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.About();
        }

        private void runToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.Run();
        }

        private void fIXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Line line in errorLines)
            {
                if (line.type == "variable")
                {
                    Refactorer.FixVariableDecleration(lineList, line);
                }

                else if (line.type == "method")
                {
                    Refactorer.FixMethodDecleration(lineList, line);
                }

                else if (line.type == "class")
                {
                    Refactorer.FixClassDecleration(lineList, line);
                }
            }

            NrichTextBox.Clear();
            foreach (Line line in lineList)
            {
                NrichTextBox.AppendText(line.text + "\n");
            }
        }

        private void NrichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            suggestionBox.Items.Clear();
            SuggestionProvider.GetSuggestion(Utility.GetLastWord());
            KeyEventsHandler.EditorKeyHandler(e);
            
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

        private void NrichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Coloring.counter == 0)
            {
                Coloring.DoFirstColoring();
            }
            Coloring.DoColoring();

            if (NrichTextBox.Text == "")
            {
                AddLineNumbers();
            }
        }

        private void NrichTextBox_KeyDown(object sender, KeyEventArgs e)
        {   if (e.KeyCode == Keys.Down && suggestionBox.Items.Count > 0)
            {
                e.Handled = true;
            }
            if (KeyEventsHandler.controlKeyPressed) {
                KeyEventsHandler.EditorMulitpleKeyPressHandler(e.KeyCode);
            }

            KeyEventsHandler.controlKeyPressed = e.Modifiers == Keys.Control;
        }

        private void NrichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                string bracket = Helper.Check(e.KeyChar);
                if (bracket != "")
                {
                    NrichTextBox.Text.Remove(NrichTextBox.Text.Length - 2, 1);
                    NrichTextBox.AppendText(bracket);
                    NrichTextBox.SelectionStart = NrichTextBox.Text.Length - 2;
                    e.Handled = true;
                }

            }

            catch (Exception) { }
        }

        private void suggestionBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyEventsHandler.SuggestionKeyHandler(e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuItemEvents.SaveFileAs();
        }

        private void BackgroundColoringHandler_DoWork(object sender, DoWorkEventArgs e)
        {
            
        }

        private void BackgroundErrorTracer_DoWork(object sender, DoWorkEventArgs e)
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

        private void BackgroundErrorTracer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
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

        private void BackgroundBracketHelper_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void BackgroundBracketHelper_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        
        }

        private void NrichTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.EditMenu.Show(e.Location);
            }

            NrichTextBox.Select();
            LineNumberTextBox.DeselectAll();
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            NrichTextBox.Copy();
        }

        private void Paste_Click(object sender, EventArgs e)
        {
            NrichTextBox.Paste();
        }

        private void Cut_Click(object sender, EventArgs e)
        {
            NrichTextBox.Cut();
        }

        private void Undo_Click(object sender, EventArgs e)
        {
            NrichTextBox.Undo();
        }

        private void Redo_Click(object sender, EventArgs e)
        {
            NrichTextBox.Redo();
        }




        //// for line numbers dont touch
        public void AddLineNumbers()
        {   
            Point pt = new Point(0, 0);    
            int First_Index = NrichTextBox.GetCharIndexFromPosition(pt);
            int First_Line = NrichTextBox.GetLineFromCharIndex(First_Index);
              
            pt.X = ClientRectangle.Width;
            pt.Y = ClientRectangle.Height;
                
            int Last_Index = NrichTextBox.GetCharIndexFromPosition(pt);
            int Last_Line = NrichTextBox.GetLineFromCharIndex(Last_Index);
               
            LineNumberTextBox.SelectionAlignment = HorizontalAlignment.Center;
                
            LineNumberTextBox.Text = "";
               
            for (int i = First_Line; i <= Last_Line+1; i++)
            {
                LineNumberTextBox.Text += i + 1 + "\n";
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            AddLineNumbers();
        }

        private void NrichTextBox_SelectionChanged(object sender, EventArgs e)
        {
            Point pt = NrichTextBox.GetPositionFromCharIndex(NrichTextBox.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }

        private void NrichTextBox_VScroll(object sender, EventArgs e)
        {
            Point pt = NrichTextBox.GetPositionFromCharIndex(NrichTextBox.SelectionStart);
            if (pt.X == 1)
            {
                AddLineNumbers();
            }
        }


    }
}
