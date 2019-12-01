using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Admin : User, WelcomeMessage
    {
        public void GetAdminMenu()
        {
            GetBasicMenu();
            Console.WriteLine("[n] Add new document\n");
            Console.WriteLine("[i] Inspect invoice\n");
            Console.WriteLine("[a] Add new user\n");
        }

        public void PrintWelcomeMessage(List<Invoice> invoices, string name)
        {
            foreach (var item in invoices)
            {
                if (DateTime.Now > item._duedate)
                {
                    overdues.Add(item);
                    _amountOfOrverdues++;
                }
            }
            Console.WriteLine("Welcome!");
            if (_amountOfOrverdues > 0)
            {
                Console.WriteLine($"Your organization has {_amountOfOrverdues} invoices overdue.");
            }
            else
            {
                Console.WriteLine("Your organization doesn't have any invoices overdue.");
            }
        }
    }
}
