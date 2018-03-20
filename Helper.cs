using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro
{
    public class Helper
    {
        private static Dictionary<char, string> openningBrackets = new Dictionary<char, string>();
        private static Dictionary<string, string> closingBrackets = new Dictionary<string, string>();
        private static Stack<char> brackets = new Stack<char>();
        public static string tabs = "";

        public static void Init()
        {
            openningBrackets.Add('(', "first");
            openningBrackets.Add('{', "second");
            openningBrackets.Add('[', "third");
            openningBrackets.Add('<', "angular");

            closingBrackets.Add("first", "(  )");
            closingBrackets.Add("second", "{  }");
            closingBrackets.Add("third", "[  ]");
            closingBrackets.Add("angular", "<  >");
        }

        public static string Check(char keyChar)
        {
            string toInsert = "";

            if (openningBrackets.ContainsKey(keyChar))
            {
                string type = openningBrackets[keyChar];
                if (keyChar == '{')
                    brackets.Push('{');
                else if(keyChar=='}' && brackets.Count!=0)
                {
                    brackets.Pop();
                }

                for(int i=0;i<brackets.Count;i++)
                {
                    tabs += "   ";
                }
                toInsert = BracketHelper(type);
            }

            return toInsert;

        }

        private static string BracketHelper(string type)
        {
            if (closingBrackets.ContainsKey(type))
            {
                return closingBrackets[type];
            }
            else return "";
        }
    }
}
