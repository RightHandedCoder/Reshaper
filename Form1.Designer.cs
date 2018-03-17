namespace NotePad_Metro
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.NrichTextBox = new System.Windows.Forms.RichTextBox();
            this.numberLabel = new System.Windows.Forms.Label();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fIXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ErrorLog = new System.Windows.Forms.RichTextBox();
            this.suggestionBox = new System.Windows.Forms.ListBox();
            this.BackgroundErrorTracer = new System.ComponentModel.BackgroundWorker();
            this.BackgroundColoringHandler = new System.ComponentModel.BackgroundWorker();
            this.BackgroundBracketHelper = new System.ComponentModel.BackgroundWorker();
            this.EditMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.LineNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.EditMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // NrichTextBox
            // 
            this.NrichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.NrichTextBox.ForeColor = System.Drawing.Color.Black;
            this.NrichTextBox.Location = new System.Drawing.Point(50, 34);
            this.NrichTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.NrichTextBox.Name = "NrichTextBox";
            this.NrichTextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.NrichTextBox.Size = new System.Drawing.Size(867, 306);
            this.NrichTextBox.TabIndex = 3;
            this.NrichTextBox.Text = "";
            this.NrichTextBox.SelectionChanged += new System.EventHandler(this.NrichTextBox_SelectionChanged);
            this.NrichTextBox.VScroll += new System.EventHandler(this.NrichTextBox_VScroll);
            this.NrichTextBox.TextChanged += new System.EventHandler(this.NrichTextBox_TextChanged);
            this.NrichTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NrichTextBox_KeyDown);
            this.NrichTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NrichTextBox_KeyPress);
            this.NrichTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.NrichTextBox_KeyUp);
            this.NrichTextBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NrichTextBox_MouseDown);
            // 
            // numberLabel
            // 
            this.numberLabel.AutoSize = true;
            this.numberLabel.Location = new System.Drawing.Point(12, 45);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(0, 20);
            this.numberLabel.TabIndex = 5;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Turquoise;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(49, 25);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.BackColor = System.Drawing.Color.Cyan;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.BackColor = System.Drawing.Color.Cyan;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.BackColor = System.Drawing.Color.Cyan;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.saveAsToolStripMenuItem.Text = "Save as";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.Cyan;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.fIXToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.Turquoise;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(52, 25);
            this.helpToolStripMenuItem.Text = "Test";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // fIXToolStripMenuItem
            // 
            this.fIXToolStripMenuItem.Name = "fIXToolStripMenuItem";
            this.fIXToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.fIXToolStripMenuItem.Text = "FIX";
            this.fIXToolStripMenuItem.Click += new System.EventHandler(this.fIXToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(4, 5);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 2, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(913, 29);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ErrorLog
            // 
            this.ErrorLog.BackColor = System.Drawing.SystemColors.Window;
            this.ErrorLog.Location = new System.Drawing.Point(4, 343);
            this.ErrorLog.Name = "ErrorLog";
            this.ErrorLog.ReadOnly = true;
            this.ErrorLog.Size = new System.Drawing.Size(751, 164);
            this.ErrorLog.TabIndex = 6;
            this.ErrorLog.Text = "";
            // 
            // suggestionBox
            // 
            this.suggestionBox.FormattingEnabled = true;
            this.suggestionBox.ItemHeight = 20;
            this.suggestionBox.Location = new System.Drawing.Point(764, 343);
            this.suggestionBox.Name = "suggestionBox";
            this.suggestionBox.Size = new System.Drawing.Size(153, 164);
            this.suggestionBox.TabIndex = 8;
            this.suggestionBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.suggestionBox_KeyDown);
            // 
            // BackgroundErrorTracer
            // 
            this.BackgroundErrorTracer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundErrorTracer_DoWork);
            this.BackgroundErrorTracer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundErrorTracer_RunWorkerCompleted);
            // 
            // BackgroundColoringHandler
            // 
            this.BackgroundColoringHandler.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundColoringHandler_DoWork);
            // 
            // BackgroundBracketHelper
            // 
            this.BackgroundBracketHelper.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundBracketHelper_DoWork);
            this.BackgroundBracketHelper.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundBracketHelper_RunWorkerCompleted);
            // 
            // EditMenu
            // 
            this.EditMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Copy,
            this.Paste,
            this.Cut,
            this.Undo,
            this.Redo});
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(109, 114);
            // 
            // Copy
            // 
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(108, 22);
            this.Copy.Text = "COPY";
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Paste
            // 
            this.Paste.Name = "Paste";
            this.Paste.Size = new System.Drawing.Size(108, 22);
            this.Paste.Text = "PASTE";
            this.Paste.Click += new System.EventHandler(this.Paste_Click);
            // 
            // Cut
            // 
            this.Cut.Name = "Cut";
            this.Cut.Size = new System.Drawing.Size(108, 22);
            this.Cut.Text = "CUT";
            this.Cut.Click += new System.EventHandler(this.Cut_Click);
            // 
            // Undo
            // 
            this.Undo.Name = "Undo";
            this.Undo.Size = new System.Drawing.Size(108, 22);
            this.Undo.Text = "UNDO";
            this.Undo.Click += new System.EventHandler(this.Undo_Click);
            // 
            // Redo
            // 
            this.Redo.Name = "Redo";
            this.Redo.Size = new System.Drawing.Size(108, 22);
            this.Redo.Text = "REDO";
            this.Redo.Click += new System.EventHandler(this.Redo_Click);
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LineNumberTextBox.Cursor = System.Windows.Forms.Cursors.PanNE;
            this.LineNumberTextBox.Location = new System.Drawing.Point(4, 37);
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.ReadOnly = true;
            this.LineNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNumberTextBox.Size = new System.Drawing.Size(46, 303);
            this.LineNumberTextBox.TabIndex = 9;
            this.LineNumberTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(921, 515);
            this.Controls.Add(this.LineNumberTextBox);
            this.Controls.Add(this.suggestionBox);
            this.Controls.Add(this.ErrorLog);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.NrichTextBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Text = "NotePad";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.EditMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox NrichTextBox;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.RichTextBox ErrorLog;
        private System.Windows.Forms.ToolStripMenuItem fIXToolStripMenuItem;
        private System.Windows.Forms.ListBox suggestionBox;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker BackgroundErrorTracer;
        private System.ComponentModel.BackgroundWorker BackgroundColoringHandler;
        private System.ComponentModel.BackgroundWorker BackgroundBracketHelper;
        private System.Windows.Forms.ContextMenuStrip EditMenu;
        private System.Windows.Forms.ToolStripMenuItem Copy;
        private System.Windows.Forms.ToolStripMenuItem Paste;
        private System.Windows.Forms.ToolStripMenuItem Cut;
        private System.Windows.Forms.ToolStripMenuItem Undo;
        private System.Windows.Forms.ToolStripMenuItem Redo;
        private System.Windows.Forms.RichTextBox LineNumberTextBox;
    }
}

