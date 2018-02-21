using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace NotePad_Metro.Logical
{
    class TokenGenerator
    {
        private readonly static string pattern_DataTypes = @"(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvar\b)";
        private readonly static string pattern_AccessModifiers = @"(\bprivate\b|\bpublic\b|\bprotected\b|\binternal\b|\bprotected\b\s\binternal\b)";
        private readonly static string pattern_ReturnTypes = @"(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvoid\b)";
        private readonly static string pattern_MethodDecleration = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvoid\b)(\s*?)(\w)(\s*?)(\w*?))";
        private readonly static string pattern_VariableDecleration = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvar\b)\s+\b\w+\b\s*?)(;|=\s*?\d*;)";
        private readonly static string pattern_ClassDecleration = @"((private|public|protected|internal|protected\sinternal)*?\s*?[class])";

        private static RichTextBox box;

        public static void InitBox(RichTextBox box)
        {
            TokenGenerator.box = box;

            return;
        }

        public static void MarkDatatypes()
        {
            MatchCollection match = Regex.Matches(box.Text, pattern_DataTypes);

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
            MatchCollection match = Regex.Matches(box.Text, pattern_AccessModifiers);

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
            MatchCollection match = Regex.Matches(box.Text, pattern_ReturnTypes);

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
            Match match = Regex.Match(word, pattern_AccessModifiers);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        public static bool IsDataType(string word)
        {
            Match match = Regex.Match(word, pattern_DataTypes);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }

        public static bool IsReturnType(string word)
        {
            Match match = Regex.Match(word, pattern_ReturnTypes);

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
                Match match = Regex.Match(line, pattern_VariableDecleration);

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
                Match match = Regex.Match(line, pattern_MethodDecleration);

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
                Match match = Regex.Match(line, pattern_ClassDecleration);

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
