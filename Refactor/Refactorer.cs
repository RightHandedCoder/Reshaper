using System.Text.RegularExpressions;
using NotePad_Metro.Library;
using NotePad_Metro.Logical;
using System.Collections.Generic;
using System.Windows.Forms;
using System;

namespace NotePad_Metro.Refactor
{
    class Refactorer
    {
        public static bool CheckVariableDecleration(string text)
        {
            Match match = Regex.Match(text, Lib_C_Sharp.Rule_VariableDecleration_CSharp);

            if (match.Success)
            {
                return true;
            }

            else return false;

        }

        public static bool CheckMethodDecleration(string text)
        {
            Match match = Regex.Match(text, Lib_C_Sharp.Rule_MethodDecleration_CSharp);

            if (match.Success)
            {
                return true;
            }

            else return false;

        }

        public static bool CheckClassDecleration(string text)
        {
            Match match = Regex.Match(text, Lib_C_Sharp.Rule_ClassDecleration_CSharp);

            if (match.Success)
            {
                return true;
            }

            else return false;
        }
        public static bool CheckConventions(Line line)
        {
            int lineNo = line.lineNumber;
            string lineText = line.text;
            string lineType = line.type;

            Match match;
            string rule = @"";
            bool result = false;

            switch (lineType)
            {
                case "variable":
                    rule = Lib_C_Sharp.Rule_VariableDecleration_CSharp;
                    break;
                case "method":
                    rule = Lib_C_Sharp.Rule_MethodDecleration_CSharp;
                    break;
                case "class":
                    rule = Lib_C_Sharp.Rule_ClassDecleration_CSharp;
                    break;
            }

            try
            {
                match = Regex.Match(lineText, rule);
                result = match.Success == true ? true : false;
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public static void FixVariableDecleration(List<Line> line, Line error)
        {
            int i = line.FindIndex(x => x.lineNumber == error.lineNumber);
            Line newLine = line[i];
            string prev = line[i].text;
            string var_name = Refactorer.ReturnVariableName(line[i].text);
            char[] new_var = var_name.ToCharArray();
            new_var[0] = Char.ToLower(new_var[0]);
            String var = new String(new_var);

            newLine.text = prev.Replace(var_name, var);
            line[i] = newLine;
        }

        public static void FixMethodDecleration(List<Line> line, Line error)
        {
            int i = line.FindIndex(x => x.lineNumber == error.lineNumber);
            Line newLine = line[i];
            string prev = line[i].text;
            string var_name = Refactorer.ReturnMethodName(line[i].text);
            char[] new_var = var_name.ToCharArray();
            new_var[0] = Char.ToUpper(new_var[0]);
            String var = new String(new_var);

            newLine.text = prev.Replace(var_name, var);
            line[i] = newLine;
        }

        public static void FixClassDecleration(List<Line> line, Line error)
        {
            int i = line.FindIndex(x => x.lineNumber == error.lineNumber);
            Line newLine = line[i];
            string prev = line[i].text;
            string var_name = Refactorer.ReturnClassName(line[i].text);
            char[] new_var = var_name.ToCharArray();
            new_var[0] = Char.ToUpper(new_var[0]);
            String var = new String(new_var);

            newLine.text = prev.Replace(var_name, var);
            line[i] = newLine;
        }

        private static string ReturnClassName(string line)
        {
            string[] sp = line.Split();

            foreach(string x in sp)
            {
                //if(!TokenGenerator.IsAccessModifier(x) && x != "class")
                //{
                //    return x;
                //}
            }

            return null;
        }

        private static string ReturnVariableName(string line)
        {
            string[] sp = line.Split();

            foreach (string x in sp)
            {
                //if (!TokenGenerator.IsAccessModifier(x) && !TokenGenerator.IsDataType(x))
                //{
                //    return x;
                //}
            }

            return null;
        }

        private static string ReturnMethodName(string line)
        {
            string[] sp = line.Split();

            foreach(string x in sp)
            {
                //if(!TokenGenerator.IsAccessModifier(x) && !TokenGenerator.IsReturnType(x))
                //{
                //    return x;
                //}
            }

            return null;
        }
        
    }


}
