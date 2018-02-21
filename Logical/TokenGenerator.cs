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
            Match matchDataType = Regex.Match(text, Tokens.pattern_DataTypes);
            Match matchAccessModifier = Regex.Match(text, Tokens.pattern_AccessModifiers);
            Match matchReturnType = Regex.Match(text, Tokens.pattern_ReturnTypes);
            Match matchClassTypes = Regex.Match(text, Tokens.pattern_ClassTypes);
            Match matchMethodDecleration = Regex.Match(text, Tokens.pattern_MethodDecleration);
            Match matchVariableDecleration = Regex.Match(text, Tokens.pattern_VariableDecleration);

            if (matchDataType.Success)
            {
                return "dataType";
            }
            else if (matchAccessModifier.Success)
            {
                return "accessModifier";
            }
            else if (matchReturnType.Success)
            {
                return "returnType";
            }
            else if (matchMethodDecleration.Success)
            {
                return "methodDecleration";
            }
            else if (matchVariableDecleration.Success)
            {
                return "variableDecleration";
            }
            else if (matchClassTypes.Success)
            {
                return "classType";
            }
            else
                return null;
        }

        public static void MarkDatatypes()
        {
            MatchCollection match = Regex.Matches(box.Text, Tokens.pattern_DataTypes);

            foreach (Match m in match)
            {
                box.Focus();

                box.SelectionStart = m.Index;
                box.SelectionLength = m.Length;
                box.SelectionColor = Color.Blue;

                box.SelectionStart = box.TextLength;
                box.SelectionColor = Color.Black;

            }
        }

        public static void MarkAccessModifiers()
        {
            MatchCollection match = Regex.Matches(box.Text, Tokens.pattern_AccessModifiers);

            foreach (Match m in match)
            {
                box.Focus();

                box.SelectionStart = m.Index;
                box.SelectionLength = m.Length;
                box.SelectionColor = Color.Red;

                box.SelectionStart = box.TextLength;
                box.SelectionColor = Color.Black;

            }
        }

        public static void MarkReturnTypes()
        {
            MatchCollection match = Regex.Matches(box.Text, Tokens.pattern_ReturnTypes);

            foreach (Match m in match)
            {
                box.Focus();

                box.SelectionStart = m.Index;
                box.SelectionLength = m.Length;
                box.SelectionColor = Color.Blue;

                box.SelectionStart = box.TextLength;
                box.SelectionColor = Color.Black;

            }
        }

        public static void MarkClass()
        {
            MatchCollection match = Regex.Matches(box.Text, "class");

            foreach (Match m in match)
            {
                box.Focus();

                box.SelectionStart = m.Index;
                box.SelectionLength = m.Length;
                box.SelectionColor = Color.Blue;

                box.SelectionStart = box.TextLength;
                box.SelectionColor = Color.Black;

            }
        }


        public static bool IsAccessModifier(string word)
        {
            Match match = Regex.Match(word, Tokens.pattern_AccessModifiers);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        public static bool IsDataType(string word)
        {
            Match match = Regex.Match(word, Tokens.pattern_DataTypes);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        public static bool IsReturnType(string word)
        {
            Match match = Regex.Match(word, Tokens.pattern_ReturnTypes);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        public static bool IsVariableDecleration(string line)
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

        public static bool IsMethodDecleration(string line)
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

        public static bool IsClassDecleration(string line)
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
