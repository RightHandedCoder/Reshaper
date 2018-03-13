using NotePad_Metro.Logical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace NotePad_Metro
{
    class LineCollection
    {
        public static List<Line> lineList = new List<Line>();

        public static void Add(Line item)
        {
            lineList.Add(item);
        }

        public static Line GetLastLine()
        {
            try
            {
                return lineList.Last();
            }
            catch (Exception)
            {
                return new Line();
            }

        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Line item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Line item)
        {
            throw new NotImplementedException();
        }
    }
}
