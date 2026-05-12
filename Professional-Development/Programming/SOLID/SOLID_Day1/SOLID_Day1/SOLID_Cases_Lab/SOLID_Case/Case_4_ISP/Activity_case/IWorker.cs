using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_4_ISP.Activity_case
{
    internal interface IWorker
    {
        void Work();      //Implemented in (Machine , Engineer)
        void TakeBreak(); //Implemented in (Machine , Engineer)
    }
}
