using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class ARSpecialist : User, WelcomeMessage
    {
        public void GetARSPecialistMenu()
        {
            GetBasicMenu();
            Console.WriteLine("[n] Add new invoice\n");
        }

        public void PrintWelcomeMessage(List<Invoice> invoices, string name)
        {
            foreach (var item in invoices)
            {
                if (item._adder == name && DateTime.Now > item._duedate)
                {
                    overdues.Add(item);
                    _amountOfOrverdues++;
                }
            }
            Console.WriteLine("Welcome!");
            if (_amountOfOrverdues > 0)
            {
                Console.WriteLine($"{_amountOfOrverdues} of the invoices you have added are overdue.");
            }
            else
            {
                Console.WriteLine("None of the invoices you have added is overdue.");
            }
        }
    }
}
