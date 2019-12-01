using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Order : Document
    {
        public string _purchaser { get; set; }


        public Order(string purchaser, string orderNumber, string supplier, double total) : base(orderNumber, supplier, total)
        {
            _purchaser = purchaser;
        }





    }
}
