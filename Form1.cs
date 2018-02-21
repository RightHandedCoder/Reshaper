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
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    Line line = new Line();
                    line.lineNumber = (NrichTextBox.Lines.Length - 1);
                    line.text = NrichTextBox.Lines[NrichTextBox.Lines.Length - 2];
                  
                    if (TokenGenerator.IsVariableDecleration(line.text))
                    {
                        line.type = "variable";
                    }

                    else if (TokenGenerator.IsMethodDecleration(line.text))
                    {
                        line.type = "method";
                    }

                    else if (TokenGenerator.IsClassDecleration(line.text))
                    {
                        line.type = "class";
                    }

                    else
                    {
                        line.type = "none";
                    }

                    lineList.Add(line);

                    NrichTextBox.SelectionStart = NrichTextBox.TextLength;
                }
                catch (Exception ex)
                {

                }
                
            }

            if (e.KeyCode == Keys.Delete)
            {
                foreach (Line line in lineList)
               {
                   if (line.type=="variable")
                   {
                       if (!Refactorer.CheckVariableDecleration(line.text))
                       {
                           Line errorLine= new Line();
                           errorLine.lineNumber = line.lineNumber;
                           errorLine.text = "// variable decleration error!";
                           errorLine.type = "variable";
                           errorLines.Add(errorLine);
                       }
                   }

                   else if (line.type=="method")
                   {
                       if (!Refactorer.CheckMethodDecleration(line.text))
                       {
                           Line errorLine= new Line();
                           errorLine.lineNumber = line.lineNumber;
                           errorLine.text = "// method decleration error!";
                           errorLine.type = "method";
                           errorLines.Add(errorLine);
                       }
                   }

                   else if (line.type=="class")
                   {
                       if (!Refactorer.CheckClassDecleration(line.text))
                       {
                           Line errorLine = new Line();
                           errorLine.lineNumber = line.lineNumber;
                           errorLine.text = "// Class decleration error!";
                           errorLine.type = "class";
                           errorLines.Add(errorLine);
                       } 
                   }
               }

                foreach (Line line in errorLines)
                {
                   ErrorLog.AppendText(line.lineNumber + " -> " + line.text+"\r\n");  
                }
            }
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
            //TokenGenerator.MarkClass();
            //TokenGenerator.MarkAccessModifiers();
            //TokenGenerator.MarkDatatypes();
            try
            {
                string[] words = NrichTextBox.Text.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Highlighter.Highlight(words[words.Length - 1]);
            }
            catch (Exception)
            {

            }
            
            SuggestionPosition();
        }

        private void NrichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case ("ControlKey"):
                    try
                    {
                        suggestionBox.Focus();
                        suggestionBox.SelectedIndex = 0;
                        break;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
            }
        }

        private void NrichTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                switch (e.KeyChar)
                {
                    case ((char)Keys.Back):
                        if (temp != null)
                        {
                            temp = temp.Remove(temp.Length - 1);
                        }
                        break;

                    case ((char)Keys.Space):
                        temp = null;
                        suggestionBox.Items.Clear();
                        break;

                    default:
                        suggestionBox.Items.Clear();
                        temp += e.KeyChar.ToString();
                        SuggestionProvider.GetSuggestion(temp);
                        break;
                }
                    
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void suggestionBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Enter):
                    SuggestionProvider.InsertSuggestion(temp);
                    NrichTextBox.Focus();
                    break;
                case (Keys.Escape):
                    suggestionBox.Items.Clear();
                    NrichTextBox.Focus();
                    break;
            }
        }

        public void SuggestionPosition()
        {
            this.NrichTextBox.Focus();
            // this.suggestionBox.Location = (Point)this.NrichTextBox.SelectionStart;
            this.suggestionBox.Location = new Point(this.NrichTextBox.SelectionStart+30, this.suggestionBox.Location.Y);
        }
    }
}
