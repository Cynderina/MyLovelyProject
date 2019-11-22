using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class ARSpecialist : User
    {
        public void GetARSPecialistMenu()
        {
            GetBasicMenu();
            Console.WriteLine("[n] Add new invoice\n");
        }
    }
}