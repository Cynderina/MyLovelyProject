using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    abstract class Document
    {
        //All documents have ordernumber, supplier and total amount of money.
        //Currency is not set for total so it is assumed that currency stays the same in order and in invoice and user inputs total from those documents
        private string _orderNumber;
        private string _supplier;
        private double _total;



        public Document(string orderNumber, string supplier, double total)
        {
            _orderNumber = orderNumber;
            _supplier = supplier;
            _total = total;

        }



        public string GetOrderNumber()
        {
            return _orderNumber;
        }

        public string GetSupplier()
        {
            return _supplier;
        }

        public double GetTotal()
        {
            return _total;
        }
    }
}