using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro
{
    class Tokens
    {
        public readonly static string pattern_DataTypes = @"(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvar\b)";
        public readonly static string pattern_AccessModifiers = @"(\bprivate\b|\bpublic\b|\bprotected\b|\binternal\b|\bprotected\b\s\binternal\b)";
        public readonly static string pattern_ReturnTypes = @"(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvoid\b)";
        public readonly static string pattern_ClassTypes = @"((private|public|protected|internal|protected\sinternal)*?\s*?[class])";

        public readonly static string pattern_MethodDecleration = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvoid\b)(\s*?)(\w)(\s*?)(\w*?))";
        public readonly static string pattern_VariableDecleration = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvar\b)\s+\b\w+\b\s*?)(;|=\s*?\d*;)";
    }
}
