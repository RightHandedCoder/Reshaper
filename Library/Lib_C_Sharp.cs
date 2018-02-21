using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro.Library
{
    class Lib_C_Sharp
    {
        private static string rule_VariableDecleration_CSharp = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvar\b)\s+\b([a-z][a-zA-Z]*)\b\s*?)(;|=\s*?\d*?\;)";
        private static string rule_MethodDecleration_CSharp = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvoid\b)(\s*?)([A-Z][a-zA-Z]*)(\s*?)(\w*?))";
        private static string rule_ClassDecleration_CSharp = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bclass\b)\s+\b([A-Z][a-zA-Z]*)\b)";

        public static string Rule_ClassDecleration_CSharp { get => rule_ClassDecleration_CSharp; }
        public static string Rule_VariableDecleration_CSharp { get => rule_VariableDecleration_CSharp; }
        public static string Rule_MethodDecleration_CSharp { get => rule_MethodDecleration_CSharp; }
    }
}
