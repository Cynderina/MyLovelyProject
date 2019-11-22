using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Invoice : Document
    {
        private string _inspector;
        private Boolean _inspected;
        //To set inspector etc data comparing we need here also some variables for ordernumber and supplier
        private string _orderNumberSetting;
        private string _supplierSetting;

        public Invoice(string orderNumber, string supplier, double total) : base(orderNumber, supplier, total)
        {

        }

        public string GetInspector()
        {
            return _inspector;
        }

        public Boolean GetInspectedStatus()
        {
            return _inspected;
        }



        //Program fetches automatically the information of purchaser from orderlist by comparing ordernumber and supplier
        public void SetInspector(string ordernumber, string supplier, List<Order> orders)
        {
            _orderNumberSetting = ordernumber;
            _supplierSetting = supplier;
            foreach (Order item in orders)
            {
                if (item.GetOrderNumber() == _orderNumberSetting && item.GetSupplier() == _supplierSetting)
                {
                    _inspector = item.GetPurchaser();
                    Console.WriteLine($"The inspector for this invoice is set {_inspector}");
                }


            }
        }

        public void SetInspectedStatus(string inspectionResult)
        {
            if (inspectionResult == "Accept")
            {
                _inspected = true;
                Console.WriteLine("Invoice accepted");
            }
            else if (inspectionResult == "Reject")
            {
                _inspected = false;
                Console.WriteLine("Invoice rejected");
            }
            else
            {
                Console.WriteLine("No changes done. Command must be either Accepted or Rejected");
            }
        }
    }
}
