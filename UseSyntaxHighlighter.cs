using SyntaxHighlighter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro
{
    class UseSyntaxHighlighter
    {
        public static void InitSyntaxHighlighter()
        {
            SyntaxRichTextBox box = new SyntaxRichTextBox();
            box.Settings.Keywords.Add("if")
        }
    }
}
