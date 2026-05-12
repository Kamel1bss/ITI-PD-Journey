using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.SOLID_Case_Answer.Case_Answer_4_ISP
{
    #region Bad Code
    public interface IMultiFunctionDevice
    {
        void Print();
        void Scan();
        void Fax();
    }

    public class OldPrinter : IMultiFunctionDevice
    {
        public void Print()
        {
            Console.WriteLine("Printing");
        }

        public void Scan()
        {
            throw new NotImplementedException();
        }

        public void Fax()
        {
            throw new NotImplementedException();
        }
    }

    public class ModernPrinter : IMultiFunctionDevice
    {
        public void Print()
        {
            Console.WriteLine("Printing");
        }

        public void Scan()
        {
            Console.WriteLine("Scanning");
        }

        public void Fax()
        {
            Console.WriteLine("Fax");
        }
    }


    #endregion

}
