using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad_Metro
{
    class Test
    {
        private RichTextBox box;
        private List<string> arrayList;
        private bool AccessModifier, ReturnType, DataType;

        public Test(RichTextBox box)
        {
            this.box = box;
            arrayList = new List<string>();
            AccessModifier = false;
            ReturnType = false;
            DataType = false;
        }

        public void SplitText()
        {
            string[] words = box.Text.Split();

            foreach (string var in words)
            {
                arrayList.Add(var);
            }

            box.Clear();
            this.Check();
        }

        private void Check()
        {
            //for (int i = 0; i < arrayList.Count; i++)
            //{
            //    AccessModifier = Logical.TokenGenerator.IsAccessModifier(arrayList[i]);
            //    DataType = Logical.TokenGenerator.IsDataType(arrayList[i]);
            //    ReturnType = Logical.TokenGenerator.IsReturnType(arrayList[i]);

            //    if (AccessModifier)
            //    {

            //    }

            //    if (DataType || ReturnType)
            //    {
            //        if (arrayList[i + 2] == ";" || arrayList[i + 2] == "=")
            //        {
            //            arrayList[i + 1] += " <"+CheckVariableName(arrayList[i + 1])+"> ";
            //        }

            //        else if (arrayList[i + 2] == "(" || arrayList[i + 2] == "()")
            //        {
            //            arrayList[i + 1] += " <" + CheckMethodName(arrayList[i + 1]) + "> ";
            //        }
            //    }
            //}

            //this.Show();
        }

        private void Show()
        {
            this.CheckParenthesis();
        }

        private void CheckParenthesis()
        {

            for (int i = 0; i < arrayList.Count; i++)
            {
                if (arrayList[i].Contains("{") && arrayList[i].Contains("}"))
                {
                    arrayList[i] = arrayList[i].Trim('{');
                    arrayList[i] = arrayList[i].Trim('}');
                    box.Text += "\r\n\n{\r\n\n" + arrayList[i].ToString() + "\r\n\n}\r\n";
                }

                else if (arrayList[i].Contains("{"))
                {
                    arrayList[i] = arrayList[i].Trim('{');
                    box.Text += "\r\n\n{\r\n\n" + arrayList[i].ToString();
                }

                else if (arrayList[i].Contains("}"))
                {
                    arrayList[i] = arrayList[i].Trim('}');
                    box.Text += arrayList[i].ToString() + "\r\n\n}\r\n";
                }



                else box.Text += " " + arrayList[i].ToString();

            }
        
        }

        private string CheckMethodName(string methodName)
        {
            char[] temp = methodName.ToArray();

            int x = (int)temp[0];

            if (x >= 97 && x <= 122)
            {
                x -= 32;

                temp[0] = (char)x;
            }

            return new String(temp);
        }

        private string CheckVariableName(string variableName)
        {
            char[] temp = variableName.ToArray();

            int x = (int)temp[0];

            if (x >= 65 && x <= 90)
            {
                x += 32;

                temp[0] = (char)x;
            }

            return new String(temp);
        }

    }
}
