using NotePad_Metro.Logical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotePad_Metro
{
    class ErrorList
    {
        private static List<Error> errorList = new List<Error>();

        public static void Add(Error error)
        {
            errorList.Add(error);
        }

        public static List<Error> GetAllErrors()
        {
            return errorList;
        }
    }
}
