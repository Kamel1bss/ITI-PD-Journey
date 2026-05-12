using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_4_ISP.Logger_case
{
    internal interface ILogger
    {
        void LogMessage(string message);
        void LogWarning(string message);
    }
}
