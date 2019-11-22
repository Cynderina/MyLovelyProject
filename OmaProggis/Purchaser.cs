using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Purchaser : User
    {
        public void GetPurchaserMenu()
        {
            GetBasicMenu();
            Console.WriteLine("[n] Add new document\n");
            Console.WriteLine("[i] Inspect invoice\n");
        }
    }
}