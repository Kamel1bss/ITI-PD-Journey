using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Lab05;
internal class Program
{
    static void Main(string[] args)
    {
        // [1]
        //Person p1 = new Person();
        //p1.FName = "Ahmed";
        //p1.LName = "Kamel";
        //p1.Age = 23;

        Person p2 = new Person { FName = "Ahmed", LName = "Kamel", Age = 23 };
        //Console.WriteLine(p1);
        //Console.WriteLine(p2);


        // [2] Rectangle

        // [3] Indexer
        //Gradebook grades = new Gradebook(5);
        //grades[0] = 95;
        //grades[1] = 88;
        //grades[2] = 72;

        //double mathGrade = grades[0];
        //Console.WriteLine(mathGrade);

        // [4] Collection
        //Collection names = new Collection(5);
        //names[0] = "Ahmed";
        //names[1] = "Sara";
        //names[2] = "Omar";

        //string a = names[0];

        //Console.WriteLine(a);
        //Console.WriteLine(names[2]);

        //Collection config = new Collection(5);
        //config["host"] = "localhost";
        //config["port"] = "8080";
        //config["db"] = "mydb";

        //string h = config["host"];
        //Console.WriteLine(h);
        //Console.WriteLine(config["db"]);

        //[5] shopping cart (ArrayList)
        //ArrayList cart = new ArrayList();
        //// Can add ANY type (not type-safe!) 
        //cart.Add(42);           // int 
        //cart.Add("Hello");      // string 
        //cart.Add(3.14);         // double 
        //cart.Add(DateTime.Now); // DateTime 
        //cart.Sort();    // Sort items 
        //cart.Reverse(); // Reverse order 
        //cart.Remove(42); // Remove item 

        //[6] List
        //List<Person> persons = new List<Person>
        //{
        //    new Person{ FName = "Ahmed", LName = "Kamel", Age = 23},
        //    new Person{ FName = "Mai", LName = "Kamel", Age = 26},
        //    new Person{ FName = "Mohamed", LName = "Kamel", Age = 29}
        //};

        //var person = persons.Find(p => p.FName == "Mai");
        //Console.WriteLine(person);
        //persons.Sort((a, b) => b.Age.CompareTo(a.Age));

        //[7] Exception handling
        //try
        //{
        //    double result = Calculator.Divide(10, 0);
        //}
        //catch (DivideByZeroException ex)
        //{
        //    Console.WriteLine("Cannot divide by zero!");
        //}
        //catch (FormatException ex)
        //{
        //    Console.WriteLine("Invalid number format!");
        //}
        //catch (Exception ex)  // General catch - MUST be last! 
        //{
        //    Console.WriteLine("Unknown error!");
        //}

        //[8] Process File try .. catch .. finally
        StreamReader reader = null;

        try
        {
            Console.WriteLine($"Opening file: ahmed.txt");
            reader = new StreamReader("ahmed.txt");

            Console.WriteLine("Reading contents...");
            string content = reader.ReadToEnd();

            Console.WriteLine($"Processing {content.Length} characters");

            if (content.Contains("ERROR"))
            {
                throw new InvalidOperationException("Found error marker in file!");
            }

            Console.WriteLine("✓ File processed successfully");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"✗ Error: File not found - {ex.Message}");
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"✗ Processing error: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Unexpected error: {ex.Message}");
        }
        finally
        {
            if (reader != null)
            {
                Console.WriteLine("→ Cleanup: Closing file stream");
                reader.Close();
            }


        }

    }
}
