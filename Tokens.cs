using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro
{
    class Tokens
    {
        private readonly static string pattern_DataTypes = @"(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvar\b)";
        private readonly static string pattern_AccessModifiers = @"(\bprivate\b|\bpublic\b|\bprotected\b|\binternal\b|\bprotected\b\s\binternal\b)";
        private readonly static string pattern_ReturnTypes = @"(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvoid\b)";
        private readonly static string pattern_MethodDecleration = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvoid\b)(\s*?)(\w)(\s*?)(\w*?))";
        private readonly static string pattern_VariableDecleration = @"((private|public|protected|internal|protected\sinternal)*?\s*?(\bs?byte\b|\bu?short\b|\bu?int\b|\bu?long\b|\bfloat\b|\bdouble\b|\bdecimal\b|\bchar\b|\bstring\b|\bbool\b|\bobject\b|\bvar\b)\s+\b\w+\b\s*?)(;|=\s*?\d*;)";
        private readonly static string pattern_ClassDecleration = @"((private|public|protected|internal|protected\sinternal)*?\s*?[class])";
    }
}
