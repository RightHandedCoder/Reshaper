using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro
{
    public class SuggestionHelper
    {
        public List<string> suggestionList = new List<string>();
        public SuggestionHelper()
        {
            this.suggestionList.Add("abstract");
            this.suggestionList.Add("async");
            this.suggestionList.Add("break");
            this.suggestionList.Add("catch");
            this.suggestionList.Add("const");
            this.suggestionList.Add("delegate");
            this.suggestionList.Add("dynamic");
            this.suggestionList.Add("explicit");
            this.suggestionList.Add("fixed");
            this.suggestionList.Add("from");
            this.suggestionList.Add("group");
            this.suggestionList.Add("int");
            this.suggestionList.Add("is");
            this.suggestionList.Add("long");
            this.suggestionList.Add("object");
            this.suggestionList.Add("out");
            this.suggestionList.Add("private");
            this.suggestionList.Add("ref");
            this.suggestionList.Add("sealed");
            this.suggestionList.Add("sizeof");
            this.suggestionList.Add("struct");
            this.suggestionList.Add("true");
            this.suggestionList.Add("ulong");
            this.suggestionList.Add("using");
            this.suggestionList.Add("void");
            this.suggestionList.Add("yield");
            this.suggestionList.Add("add");
            this.suggestionList.Add("await");
            this.suggestionList.Add("by");
            this.suggestionList.Add("char");
            this.suggestionList.Add("continue");
            this.suggestionList.Add("descending");
            this.suggestionList.Add("else");
            this.suggestionList.Add("extern");
            this.suggestionList.Add("float");
            this.suggestionList.Add("get");
            this.suggestionList.Add("if");
            this.suggestionList.Add("interface");
            this.suggestionList.Add("join");
            this.suggestionList.Add("namespace");
            this.suggestionList.Add("on");
            this.suggestionList.Add("override");
            this.suggestionList.Add("protected");
            this.suggestionList.Add("remove");
            this.suggestionList.Add("select");
            this.suggestionList.Add("stackalloc");
            this.suggestionList.Add("switch");
            this.suggestionList.Add("try");
            this.suggestionList.Add("unchecked");
            this.suggestionList.Add("value");
            this.suggestionList.Add("volatile");
            this.suggestionList.Add("as");
            this.suggestionList.Add("base");
            this.suggestionList.Add("byte");
            this.suggestionList.Add("checked");
            this.suggestionList.Add("decimal");
            this.suggestionList.Add("do");
            this.suggestionList.Add("enum");
            this.suggestionList.Add("false");
            this.suggestionList.Add("for");
            this.suggestionList.Add("global");
            this.suggestionList.Add("implicit");
            this.suggestionList.Add("internal");
            this.suggestionList.Add("let");
            this.suggestionList.Add("new");
            this.suggestionList.Add("operator");
            this.suggestionList.Add("params");
            this.suggestionList.Add("public");
            this.suggestionList.Add("return");
            this.suggestionList.Add("set");
            this.suggestionList.Add("static");
            this.suggestionList.Add("this");
            this.suggestionList.Add("typeof");
            this.suggestionList.Add("unsafe");
            this.suggestionList.Add("var");
            this.suggestionList.Add("where");
            this.suggestionList.Add("ascending");
            this.suggestionList.Add("bool");
            this.suggestionList.Add("case");
            this.suggestionList.Add("class");
            this.suggestionList.Add("default");
            this.suggestionList.Add("double");
            this.suggestionList.Add("equals");
            this.suggestionList.Add("finally");
            this.suggestionList.Add("foreach");
            this.suggestionList.Add("goto");
            this.suggestionList.Add("in");
            this.suggestionList.Add("into");
            this.suggestionList.Add("lock");
            this.suggestionList.Add("null");
            this.suggestionList.Add("orderby");
            this.suggestionList.Add("partial");
            this.suggestionList.Add("readonly");
            this.suggestionList.Add("sbyte");
            this.suggestionList.Add("short");
            this.suggestionList.Add("string");
            this.suggestionList.Add("throw");
            this.suggestionList.Add("uint");
            this.suggestionList.Add("ushort");
            this.suggestionList.Add("virtual");
            this.suggestionList.Add("while");
        }

        public void AddList(string s)
        {
            this.suggestionList.Add(s);
        }

        public List<string> GetSuggestionList()
        {
            return this.suggestionList;
        }
    }
}
