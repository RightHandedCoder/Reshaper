using NotePad_Metro.Logical;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Metro
{
    class Highlighter
    {
        private static RichTextBox editor;

        public static void Init(RichTextBox box)
        {
            editor = box;
        }

        public static Color TextColor(string text)
        {
            string temp = TokenGenerator.GenerateToken(text);
            Color color;

            switch(temp)
            {
                case "dataType":
                    color = Color.Blue;
                    break;
                case "accessModifier":
                    color = Color.Red;
                    break;
                case "returnType":
                    color = Color.Blue;
                    break;
                case "classType":
                    color = Color.Green;
                    break;
                default:
                    color = Color.Black;
                    break;
            }

            return color;
        }

        public static void Highlight(string text)
        {
            Color color = TextColor(text);

            try
            {
                editor.Focus();
                int startIndex = editor.Text.LastIndexOf(' ') == -1 ? 0 : editor.Text.LastIndexOf(' ');
                int selectionLength = editor.SelectionStart;

                editor.SelectionStart = startIndex;
                editor.SelectionLength = selectionLength;
                editor.SelectionColor = color;
                editor.SelectionStart = editor.TextLength;
                editor.SelectionColor = Color.Black;
            }
            catch (Exception)
            {

            }
        }
    }
}
