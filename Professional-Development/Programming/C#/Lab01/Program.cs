using System.Collections.Specialized;
using System.Data.SqlTypes;

namespace Lab01
{
    enum JobPosition
    {
        Admin = 1,
        Engineer,
        Technician
    }

    enum JobType
    {
        FullTime = 1,
        PartTime
    }

    struct Student
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public double Salary { get; set; }
        public JobType jobType { get; set; }
        public JobPosition jobPosition { get; set; }
    }
    internal class Program
    {
        static void printStudent(Student s)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("  Student info ");
            Console.WriteLine("=================");
            Console.WriteLine($"Id: {s.Id}");
            Console.WriteLine($"Name: {s.Name}");
            Console.WriteLine($"Salary: {s.Salary}");
            Console.WriteLine($"Position: {s.jobPosition}");
            Console.WriteLine($"Job Type: {s.jobType}");
            Console.WriteLine("==============================");
        }
        static void Main(string[] args)
        {
            Student s1 = new Student();
            Console.WriteLine("  Enter your data: ");
            Console.WriteLine("====================");
            Console.Write("Id: ");
            s1.Id = int.Parse(Console.ReadLine());
            Console.Write("Name: ");
            s1.Name = Console.ReadLine();
            Console.Write("Salary: ");
            s1.Salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Job Position: ");
            Console.WriteLine("====================");
            Console.WriteLine("1) Admin ");
            Console.WriteLine("2) Engineer ");
            Console.WriteLine("3) Technician ");
            Console.Write("> ");
            int jobPosition = int.Parse(Console.ReadLine());
            s1.jobPosition = (JobPosition)jobPosition;
            

            Console.WriteLine("Job Type: ");
            Console.WriteLine("====================");
            Console.WriteLine("1) Full-time ");
            Console.WriteLine("2) Part-time ");
            Console.Write("> ");
            int jobType = int.Parse(Console.ReadLine());
            s1.jobType = (JobType)jobType;

            printStudent(s1);
            
        }
    }
}
