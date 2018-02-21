using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro.Logical
{
    struct Line
    {
        public int lineNumber;
        public string text;
        public string type;
    }

    struct Error
    {
        public int lineNumber;
        public string errorType;
    }
}
