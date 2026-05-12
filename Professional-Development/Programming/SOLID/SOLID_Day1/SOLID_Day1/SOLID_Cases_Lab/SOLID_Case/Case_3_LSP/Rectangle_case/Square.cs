using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_3_LSP.Rectangle_case
{
    internal class Square : Shape
    {
        public int SideLength { get; set; }
        public override int GetArea()
        {
            return SideLength * SideLength;
        }
    }
}
