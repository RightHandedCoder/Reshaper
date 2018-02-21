using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace NotePad_Metro.Logical
{
    class TokenGenerator
    {
        private static RichTextBox box;

        public static void InitBox(RichTextBox box)
        {
            TokenGenerator.box = box;

            return;
        }

        public static string GenerateToken(string text)
        {
            string type = "none";

            if (IsDataType(text))
            {
                type = "dataType";
            }
            if (IsAccessModifier(text))
            {
                type = "accessModifier";
            }
            if (IsReturnType(text))
            {
                type = "returnType";
            }
            //if (IsClassDecleration(text))
            //{
            //    type = "classType";
            //}
            if (IsMethodDecleration(text))
            {
                type = "methodDecleration";
            }
            if (IsVariableDecleration(text))
            {
                type = "variableDecleration";
            }

            return type;
                
        }

        private static bool IsAccessModifier(string word)
        {
            Match match = Regex.Match(word, Tokens.pattern_AccessModifiers);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        private static bool IsDataType(string word)
        {
            Match match = Regex.Match(word, Tokens.pattern_DataTypes);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        private static bool IsReturnType(string word)
        {
            Match match = Regex.Match(word, Tokens.pattern_ReturnTypes);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        private static bool IsVariableDecleration(string line)
        {
            if (line != null)
            {
                Match match = Regex.Match(line, Tokens.pattern_VariableDecleration);

                if (match.Success)
                {

                    return true;

                }
                else return false;
            }

            else return false;

        }

        private static bool IsMethodDecleration(string line)
        {
            if (line != null)
            {
                Match match = Regex.Match(line, Tokens.pattern_MethodDecleration);

                if (match.Success)
                {

                    return true;

                }
                else return false;
            }

            else return false;

        }

        private static bool IsClassDecleration(string line)
        {
            if (line != null)
            {
                Match match = Regex.Match(line, Tokens.pattern_ClassTypes);

                if (match.Success)
                {
                    return true;
                }

                else return false;
            }

            else return false;
        }
    }
}
