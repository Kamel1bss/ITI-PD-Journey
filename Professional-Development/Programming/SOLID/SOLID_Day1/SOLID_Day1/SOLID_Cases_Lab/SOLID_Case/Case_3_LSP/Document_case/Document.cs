using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case.Case_3_LSP.Document_case
{
    internal class Document : IPrintable
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public void Print()
        {
            throw new NotImplementedException();
        }
        // domain model properties and methods
    }
}
