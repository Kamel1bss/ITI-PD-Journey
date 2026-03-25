// LINQ DAY01
namespace LINQ01;
internal class Program
{
    static void Main(string[] args)
    {
        // LINQ - Language Integrated Query
        // var (implicitly typed local variable)
        // anyonmous object
        // extension methods
        // Sequence [yeild keyword]


        // Linq to objects
        // Linq to sql
        // Linq to XML
        // query operator, query expression


        //var filteredCourses = Data.Courses.Filter(c => c.Hours > 30);
        //var selectedData = filteredCourses.Choose(c => new {c.Name, c.Hours});

        // query operator
        //var query = Data.Courses.Filter(c => c.Hours > 30).Choose(c => new { c.Name, c.Hours });

        // query expression
        var query = from course in Data.Courses  // [start from => ends select OR groupBy]
                   where course.Hours > 30
                   select new { course.Name, course.Hours };

        foreach (var data in query)
        {
            Console.WriteLine(data.Name);
        }

    }

}
