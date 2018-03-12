using NotePad_Metro.Logical;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public void ColorWords(BackgroundWorker worker, DoWorkEventArgs e)
        {
            
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
    }
}
