using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_2_OCP.Drawing_case
{
    public class GoodDrawing
    {
        private readonly IDraw _draw;
        public GoodDrawing(IDraw draw)
        {
            _draw = draw;
        }

        public string DrawShape()
        {
            string result = string.Empty;
    
            result = _draw.Draw();

            return result;
        }
    }
}
