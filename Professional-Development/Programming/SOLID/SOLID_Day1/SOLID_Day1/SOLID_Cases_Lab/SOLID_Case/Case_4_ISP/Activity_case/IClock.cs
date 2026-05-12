using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_4_ISP.Activity_case
{
    internal interface IClock
    {
        void ClockIn();   //Implemented in (Employee , Engineer)
        void ClockOut();  //Implemented in (Employee , Engineer)
    }
}
