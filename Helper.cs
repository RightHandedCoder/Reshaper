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
        public static int tabs = 0;

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
                if(keyChar=='{')
                {
                    tabs++;
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
