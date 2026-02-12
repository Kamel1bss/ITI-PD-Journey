using System;

namespace Lab06;

public delegate double OperationHandler(double a, double b);
public delegate void NotifyHandler(string msg);
public delegate bool FilterHandler(int num);
internal class Program
{

    static void Main(string[] args)
    {
        // [1] Delegate
        //OperationHandler operation = Calculator.Add;
        //Console.WriteLine($"Addition: {operation(45, 45)}");
        //operation = Calculator.Multiply;
        //Console.WriteLine($"Multiplication: {operation(45, 45)}");

        // [2] Multicast Delgate
        //NotifyHandler notify = Notification.SendEmail;
        //notify += Notification.SendSMS;
        //notify += Notification.LogToFile;

        //notify("Order confirmed");

        //notify -= Notification.SendSMS;
        //notify("Shipped!");

        // [3] Filter with delegate
        //List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //List<int> even = Filter.Array(arr, Filter.Method.isEven);
        //foreach (int i in even) { Console.Write($"{i} "); }
        //Console.WriteLine();
        //List<int> odd = Filter.Array(arr, Filter.Method.isOdd);
        //foreach (int i in odd) { Console.Write($"{i} "); }
        //Console.WriteLine();
        //List<int> largeThan5 = Filter.Array(arr, Filter.Method.isGreaterThan5);
        //foreach (int i in largeThan5) { Console.Write($"{i} "); }
        //Console.WriteLine();

        // [4] Anoynums methods
        //List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //List<int> even = Filter.Array(arr, delegate(int num){ return num % 2 ==0 ; });
        //foreach (int i in even) { Console.Write($"{i} "); }
        //Console.WriteLine();
        //List<int> odd = Filter.Array(arr, delegate (int num) { return num % 2 != 0; });
        //foreach (int i in odd) { Console.Write($"{i} "); }
        //Console.WriteLine();
        //List<int>largeThan5 = Filter.Array(arr, delegate (int num) { return num > 5; });
        //foreach (int i in largeThan5) { Console.Write($"{i} "); }
        //Console.WriteLine();

        // [5] Lambda Expression 
        //List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //List<int> even = Filter.Array(arr, (num) => num % 2 == 0);
        //foreach (int i in even) { Console.Write($"{i} "); }
        //Console.WriteLine();
        //List<int> odd = Filter.Array(arr, (num) => num % 2 != 0);
        //foreach (int i in odd) { Console.Write($"{i} "); }
        //Console.WriteLine();
        //List<int>largeThan5 = Filter.Array(arr, (num) => num > 5);
        //foreach (int i in largeThan5) { Console.Write($"{i} "); }
        //Console.WriteLine();

        // [6] Lambda Expression sorting
        //List<Person> people = new List<Person>
        //{
        //    new Person { Id = 1, Name = "Ahmed", Age = 22, Department = "IT" },
        //    new Person { Id = 2, Name = "Mona", Age = 25, Department = "HR" },
        //    new Person { Id = 3, Name = "Khaled", Age = 30, Department = "Finance" },
        //    new Person { Id = 4, Name = "Sara", Age = 27, Department = "Marketing" }
        //};

        //// Sort by Age asc
        //people.Sort((a, b) => a.Age.CompareTo(b.Age));
        //// Sort by Age desc
        //people.Sort((a, b) => b.Age.CompareTo(a.Age)); 

        //people.Sort((a, b) => a.Name.CompareTo(b.Name));
        //// Sort by multiple criteria
        //people.Sort((a, b) => {
        //    int result = a.Department.CompareTo(b.Department);
        //    if (result != 0) return result;
        //    return a.Name.CompareTo(b.Name);
        //});

        // [7] Temperature Monitor
        //TempMonitor.TemperatureHigh += TempSensor.OnHighTemp;
        //TempMonitor.TemperatureLow += TempSensor.OnLowTemp;
        //TempMonitor.SetTemperature(2);

        // [8] Button Click
        // Subscribe handlers 

        //Button button = new Button();
        //Handler handler = new Handler();
        //Logger logger = new Logger();

        //button.Click += handler.OnClick;
        //button.Click += logger.LogClick;
        //button.Click += (sender, name) => Console.WriteLine($"Clicked: {name}");
        //// Trigger 
        //button.PerformClick();  // All 3 handlers called!

    }
}
