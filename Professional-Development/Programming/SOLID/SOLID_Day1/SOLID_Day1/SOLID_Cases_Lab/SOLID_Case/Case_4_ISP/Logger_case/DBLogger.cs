using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_4_ISP.Logger_case
{
    internal class DBLogger : ILogger, ILogError
    {
        public void LogError(string message)
        {
            throw new NotImplementedException();
        }

        public void LogMessage(string message)
        {
            throw new NotImplementedException();
        }

        public void LogWarning(string message)
        {
            throw new NotImplementedException();
        }
    }
}
