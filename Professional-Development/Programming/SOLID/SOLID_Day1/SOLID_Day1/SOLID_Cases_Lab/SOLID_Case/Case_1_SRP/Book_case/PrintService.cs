using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_1_SRP.Book_case
{
    internal class PrintService
    {
        public void Print(BookDTO book)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}");
        }
    }
}
