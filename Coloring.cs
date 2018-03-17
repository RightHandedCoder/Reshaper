using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Metro
{
    class Coloring
    {
        private static Dictionary<string, Color> suggestions = new Dictionary<string, Color>();
        private static RichTextBox editor;
        

        public static void InitColoring(RichTextBox NRichTextBox)
        {
            editor = NRichTextBox;
            suggestions.Add("abstract", Color.DarkBlue);
            suggestions.Add("async", Color.Blue);
            suggestions.Add("break", Color.CadetBlue);
            suggestions.Add("catch", Color.Blue);
            suggestions.Add("const", Color.Blue);
            suggestions.Add("delegate", Color.DarkBlue);
            suggestions.Add("dynamic", Color.DarkCyan);
            suggestions.Add("explicit", Color.Blue);
            suggestions.Add("fixed", Color.Blue);
            suggestions.Add("from", Color.Blue);
            suggestions.Add("group", Color.Blue);
            suggestions.Add("int", Color.DarkViolet);
            suggestions.Add("is", Color.Blue);
            suggestions.Add("long", Color.Blue);
            suggestions.Add("object", Color.Blue);
            suggestions.Add("out", Color.Blue);
            suggestions.Add("private", Color.Cyan);
            suggestions.Add("ref", Color.Blue);
            suggestions.Add("sealed", Color.Blue);
            suggestions.Add("sizeof", Color.Blue);
            suggestions.Add("struct", Color.CadetBlue);
            suggestions.Add("true", Color.Green);
            suggestions.Add("ulong", Color.DarkViolet);
            suggestions.Add("using", Color.Blue);
            suggestions.Add("void", Color.Brown);
            suggestions.Add("yield", Color.Blue);
            suggestions.Add("add", Color.Blue);
            suggestions.Add("await", Color.Blue);
            suggestions.Add("by", Color.Blue);
            suggestions.Add("char", Color.DarkViolet);
            suggestions.Add("continue", Color.Blue);
            suggestions.Add("descending", Color.Blue);
            suggestions.Add("else", Color.SlateBlue);
            suggestions.Add("extern", Color.Blue);
            suggestions.Add("float", Color.DarkViolet);
            suggestions.Add("get", Color.Blue);
            suggestions.Add("if", Color.SlateBlue);
            suggestions.Add("interface", Color.DarkBlue);
            suggestions.Add("join", Color.Blue);
            suggestions.Add("namespace", Color.DarkSeaGreen);
            suggestions.Add("on", Color.Blue);
            suggestions.Add("override", Color.Khaki);
            suggestions.Add("protected", Color.Cyan);
            suggestions.Add("remove", Color.Blue);
            suggestions.Add("select", Color.Blue);
            suggestions.Add("stackalloc", Color.Blue);
            suggestions.Add("switch", Color.Blue);
            suggestions.Add("try", Color.SlateBlue);
            suggestions.Add("unchecked", Color.Blue);
            suggestions.Add("value", Color.Blue);
            suggestions.Add("volatile", Color.Blue);
            suggestions.Add("as", Color.Blue);
            suggestions.Add("base", Color.Blue);
            suggestions.Add("byte", Color.DarkViolet);
            suggestions.Add("checked", Color.Blue);
            suggestions.Add("decimal", Color.Blue);
            suggestions.Add("do", Color.Blue);
            suggestions.Add("enum", Color.Blue);
            suggestions.Add("false", Color.Yellow);
          
            suggestions.Add("for", Color.SlateBlue);
            suggestions.Add("global", Color.Blue);
            suggestions.Add("implicit", Color.Blue);
            suggestions.Add("internal", Color.Blue);
            suggestions.Add("let", Color.Blue);
            suggestions.Add("new", Color.Blue);
            suggestions.Add("operator", Color.Blue);
            suggestions.Add("params", Color.Blue);
            suggestions.Add("public", Color.Cyan);
            suggestions.Add("return", Color.DarkSeaGreen);
            suggestions.Add("set", Color.Blue);
            suggestions.Add("static", Color.Blue);
            suggestions.Add("this", Color.Blue);
            suggestions.Add("typeof", Color.Blue);
            suggestions.Add("unsafe", Color.Blue);
            suggestions.Add("var", Color.DarkViolet);
            suggestions.Add("where", Color.SlateBlue);
            suggestions.Add("ascending", Color.Blue);
            suggestions.Add("bool", Color.Blue);
            suggestions.Add("case", Color.Blue);
            suggestions.Add("class", Color.DarkCyan);
            suggestions.Add("default", Color.Blue);
            suggestions.Add("double", Color.DarkViolet);
            suggestions.Add("equals", Color.Blue);
            suggestions.Add("finally", Color.Blue);
            suggestions.Add("foreach", Color.SlateBlue);
            suggestions.Add("goto", Color.Blue);
            suggestions.Add("in", Color.Blue);
            suggestions.Add("into", Color.Blue);
            suggestions.Add("lock", Color.Blue);
            suggestions.Add("null", Color.DarkRed);
            suggestions.Add("orderby", Color.Blue);
            suggestions.Add("partial", Color.Blue);
            suggestions.Add("readonly", Color.Blue);
            suggestions.Add("sbyte", Color.DarkViolet);
            suggestions.Add("short", Color.DarkViolet);
            suggestions.Add("string", Color.DarkViolet);
            suggestions.Add("throw", Color.Blue);
            suggestions.Add("uint", Color.Blue);
            suggestions.Add("ushort", Color.DarkViolet);
            suggestions.Add("virtual", Color.LightBlue);
            suggestions.Add("while", Color.Cyan);
            suggestions.Add("Catch", Color.ForestGreen);
        }

        public static bool InList(string word)
        {
            if (suggestions.ContainsKey(word))
            {
                return true;
            }
            else return false;
        }

        public static Color GetColor(string word)
        {
            if (InList(word))
            {
                return suggestions[word];
            }

            else return Color.Black;
        }

        public static void DoColoring()
        {
            try
            {
                foreach (string word in editor.Text.Split())
                {
                    int index = editor.Text.LastIndexOf(word);
                    int selectStart = editor.SelectionStart;
                    editor.Select(index, word.Length);
                    editor.SelectionColor = GetColor(word);
                    editor.Select(selectStart, 0);
                    editor.SelectionColor = Color.Black;
                }

            }
            catch (Exception) { }
        }
    }
}
