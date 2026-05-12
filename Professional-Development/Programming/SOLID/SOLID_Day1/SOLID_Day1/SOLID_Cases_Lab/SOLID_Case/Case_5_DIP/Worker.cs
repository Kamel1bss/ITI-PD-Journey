using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Implement_2._2_5_DIP
{
    #region Bad Code
    public class Manager
    {
        public void AssignTask() { }
    }

    public class Worker
    {
        private Manager _manager = new Manager();

        public void DoTask()
        {
            _manager.AssignTask();
        }
    }
    #endregion
}
