using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_1_SRP
{
    #region Bad Code

    public class Employee
    {
        public void SaveEmployee(Employee employee)
        {
            // Code to save employee to the database
        }

        public void CalculateSalary(Employee employee)
        {
            // Code to calculate employee's salary
        }
    }

    #endregion
}
