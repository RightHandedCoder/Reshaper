using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NotePad_Metro.Refactor;
using NotePad_Metro.Logical;
using System.Drawing;

namespace NotePad_Metro
{
    public partial class Form1 : Form
    {
        Test t;
        
        string[] arr = new string[1000];
        List<Line> lineList = new List<Line>();
        List<Line> errorLines = new List<Line>();
        string temp;


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
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NrichTextBox.Clear();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                NrichTextBox.LoadFile(op.FileName, RichTextBoxStreamType.PlainText);
                this.Text = op.FileName;
            }
            else { }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (save.ShowDialog() == DialogResult.OK)
            {
                NrichTextBox.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
                this.Text = save.FileName;
            }
            else
            { }

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
            t.SplitText();
            //t.Show();
        }
      
        private void NrichTextBox_KeyUp(object sender, KeyEventArgs e)
        {
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
            try
            {
                string[] words = NrichTextBox.Text.Split(new[] { ' ', '\n', ';' });
                string lastWord = words[words.Length - 1];
                Color color = Highlighter.TextColor(lastWord);
                Utility.AddColorToText(lastWord, color);
            }
            catch (Exception) { }
            
            SuggestionPosition();
        }

        private void NrichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.K && e.Modifiers == Keys.Control)
            {
                //NrichTextBox.SelectedText
                //Line CommentLine = new Line();
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


                    //MessageBox.Show(s);
                }
                s = s.Remove(s.Length - 1);
                NrichTextBox.SelectedText = NrichTextBox.SelectedText.Replace(NrichTextBox.SelectedText, s);
            }
        }

        private void NrichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                suggestionBox.Items.Clear();
                Utility.AddToTemp(e.KeyChar);
                SuggestionProvider.GetSuggestion(Utility.GetTemp());

            }

            catch (Exception) { }
        }

        private void suggestionBox_KeyDown(object sender, KeyEventArgs e)
        {
            KeyEventsHandler.SuggestionKeyHandler(e.KeyCode);
        }

        public void SuggestionPosition()
        {
            //this.NrichTextBox.Focus();
            //// this.suggestionBox.Location = (Point)this.NrichTextBox.SelectionStart;
            //this.suggestionBox.Location = new Point(this.NrichTextBox.SelectionStart+30, this.suggestionBox.Location.Y);
        }
    }
}
