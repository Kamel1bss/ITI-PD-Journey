using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_1_SRP.Employee_case
{
    internal class SalaryService
    {
        public void CalculateSalary(EmployeeDTO employee)
        {
            // Code to calculate employee's salary
            Console.WriteLine($"Employee {employee} salary calculated.");
        }

    }
}
