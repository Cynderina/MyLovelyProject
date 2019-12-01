using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Purchaser : User, WelcomeMessage
    {


        public void GetPurchaserMenu()
        {
            GetBasicMenu();
            Console.WriteLine("[n] Add new document\n");
            Console.WriteLine("[i] Inspect invoice\n");
        }

        public void PrintWelcomeMessage(List<Invoice> invoices, string name)
        {
            foreach (var item in invoices)
            {
                if (item.GetInspector() == name && DateTime.Now > item._duedate)
                {
                    overdues.Add(item);
                    _amountOfOrverdues++;
                }
            }
            Console.WriteLine("Welcome!");
            if (_amountOfOrverdues > 0)
            {
                Console.WriteLine($"You have {_amountOfOrverdues} invoices to inspect that are overdue.");
            }
            else
            {
                Console.WriteLine("You have no invoices to inspect that are overdue.");
            }
        }
    }
}
