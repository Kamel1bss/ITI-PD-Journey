using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SOLID.SOLID_Case.Case_1_SRP.Employee_case
{
    internal class EmployeeRepository
    {
        public void Save(EmployeeDTO employee)
        {
            // Code to save the employee to a database or file
            Console.WriteLine($"Employee {employee} saved.");
        }
    }
}
