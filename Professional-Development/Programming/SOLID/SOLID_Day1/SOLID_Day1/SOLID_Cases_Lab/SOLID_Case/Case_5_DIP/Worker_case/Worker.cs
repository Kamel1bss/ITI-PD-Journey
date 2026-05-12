using SOLID.SOLID_Implement_2._2_5_DIP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_5_DIP.Worker_case
{
    internal class Worker
    {
        private readonly ITaskHandler _taskHandler;
        public Worker(ITaskHandler taskHandler)
        {
            _taskHandler = taskHandler;
        }

        public void DoTask()
        {
            _taskHandler.AssignTask();
        }
    }
}
