using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Order : Document
    {
        private string _purchaser;

        public Order(string purchaser, string orderNumber, string supplier, double total) : base(orderNumber, supplier, total)
        {
            _purchaser = purchaser;
        }

        public string GetPurchaser()
        {
            return _purchaser;
        }



    }
}