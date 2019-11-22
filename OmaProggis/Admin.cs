using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Admin : User
    {
        public void GetAdminMenu()
        {
            GetBasicMenu();
            Console.WriteLine("[n] Add new document\n");
            Console.WriteLine("[i] Inspect invoice\n");
            Console.WriteLine("[a] Add new user\n");
        }
    }
}