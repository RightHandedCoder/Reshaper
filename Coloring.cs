using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro
{
    class Coloring
    {
        private static Dictionary<string, Color> suggestions = new Dictionary<string, Color>();

        public static void InitColoring()
        {
            suggestions.Add("abstract", Color.Blue);
            suggestions.Add("async", Color.Blue);
            suggestions.Add("break", Color.Blue);
            suggestions.Add("catch", Color.Blue);
            suggestions.Add("const", Color.Blue);
            suggestions.Add("delegate", Color.Blue);
            suggestions.Add("dynamic", Color.Blue);
            suggestions.Add("explicit", Color.Blue);
            suggestions.Add("fixed", Color.Blue);
            suggestions.Add("from", Color.Blue);
            suggestions.Add("group", Color.Blue);
            suggestions.Add("int", Color.Blue);
            suggestions.Add("is", Color.Blue);
            suggestions.Add("long", Color.Blue);
            suggestions.Add("object", Color.Blue);
            suggestions.Add("out", Color.Blue);
            suggestions.Add("private", Color.Blue);
            suggestions.Add("ref", Color.Blue);
            suggestions.Add("sealed", Color.Blue);
            suggestions.Add("sizeof", Color.Blue);
            suggestions.Add("struct", Color.Blue);
            suggestions.Add("true", Color.Blue);
            suggestions.Add("ulong", Color.Blue);
            suggestions.Add("using", Color.Blue);
            suggestions.Add("void", Color.Blue);
            suggestions.Add("yield", Color.Blue);
            suggestions.Add("add", Color.Blue);
            suggestions.Add("await", Color.Blue);
            suggestions.Add("by", Color.Blue);
            suggestions.Add("char", Color.Blue);
            suggestions.Add("continue", Color.Blue);
            suggestions.Add("descending", Color.Blue);
            suggestions.Add("else", Color.Blue);
            suggestions.Add("extern", Color.Blue);
            suggestions.Add("float", Color.Blue);
            suggestions.Add("get", Color.Blue);
            suggestions.Add("if", Color.Blue);
            suggestions.Add("interface", Color.Blue);
            suggestions.Add("join", Color.Blue);
            suggestions.Add("namespace", Color.Blue);
            suggestions.Add("on", Color.Blue);
            suggestions.Add("override", Color.Blue);
            suggestions.Add("protected", Color.Blue);
            suggestions.Add("remove", Color.Blue);
            suggestions.Add("select", Color.Blue);
            suggestions.Add("stackalloc", Color.Blue);
            suggestions.Add("switch", Color.Blue);
            suggestions.Add("try", Color.Blue);
            suggestions.Add("unchecked", Color.Blue);
            suggestions.Add("value", Color.Blue);
            suggestions.Add("volatile", Color.Blue);
            suggestions.Add("as", Color.Blue);
            suggestions.Add("base", Color.Blue);
            suggestions.Add("byte", Color.Blue);
            suggestions.Add("checked", Color.Blue);
            suggestions.Add("decimal", Color.Blue);
            suggestions.Add("do", Color.Blue);
            suggestions.Add("enum", Color.Blue);
            suggestions.Add("false", Color.Blue);
            suggestions.Add("for", Color.Blue);
            suggestions.Add("global", Color.Blue);
            suggestions.Add("implicit", Color.Blue);
            suggestions.Add("internal", Color.Blue);
            suggestions.Add("let", Color.Blue);
            suggestions.Add("new", Color.Blue);
            suggestions.Add("operator", Color.Blue);
            suggestions.Add("params", Color.Blue);
            suggestions.Add("public", Color.Blue);
            suggestions.Add("return", Color.Blue);
            suggestions.Add("set", Color.Blue);
            suggestions.Add("static", Color.Blue);
            suggestions.Add("this", Color.Blue);
            suggestions.Add("typeof", Color.Blue);
            suggestions.Add("unsafe", Color.Blue);
            suggestions.Add("var", Color.Blue);
            suggestions.Add("where", Color.Blue);
            suggestions.Add("ascending", Color.Blue);
            suggestions.Add("bool", Color.Blue);
            suggestions.Add("case", Color.Blue);
            suggestions.Add("class", Color.Blue);
            suggestions.Add("default", Color.Blue);
            suggestions.Add("double", Color.Blue);
            suggestions.Add("equals", Color.Blue);
            suggestions.Add("finally", Color.Blue);
            suggestions.Add("foreach", Color.Blue);
            suggestions.Add("goto", Color.Blue);
            suggestions.Add("in", Color.Blue);
            suggestions.Add("into", Color.Blue);
            suggestions.Add("lock", Color.Blue);
            suggestions.Add("null", Color.Blue);
            suggestions.Add("orderby", Color.Blue);
            suggestions.Add("partial", Color.Blue);
            suggestions.Add("readonly", Color.Blue);
            suggestions.Add("sbyte", Color.Blue);
            suggestions.Add("short", Color.Blue);
            suggestions.Add("string", Color.Blue);
            suggestions.Add("throw", Color.Blue);
            suggestions.Add("uint", Color.Blue);
            suggestions.Add("ushort", Color.Blue);
            suggestions.Add("virtual", Color.Blue);
            suggestions.Add("while", Color.Blue);
        }

        public static bool InList(string word)
        {
            if (suggestions.ContainsKey(word))
            {
                return true;
            }
            else return false;
        }
    }
}
