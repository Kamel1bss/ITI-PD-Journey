using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_3_LSP.Rectangle_case
{
    internal class Rectangle : Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public override int GetArea()
        {
            return Width * Height;
        }
    }
}
