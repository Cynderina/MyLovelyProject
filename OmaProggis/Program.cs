using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Inheritance
{
    class Program
    {
        //Pilko toimintoja metodeihin enemmän switcheistä. Luettavuus paranee
        // Poista turhat muuttujat

        static void OrderInput(string purchaser, string orderNumber, string supplier, double total)
        {

            var connString = "Host=localhost;Username=postgres;Password=Grespost99;Database=project";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open(); // Here we open connection
                             // Here we define our SQL query

                using (var cmd = new NpgsqlCommand("INSERT INTO orders VALUES (default, @ordernumber, @supplier, @total, @purchaser);", conn))
                {
                    //ExecuteNonQueryAsync versio ei jää odottamaan, että datan tallennus tietokannassa on valmis
                    //komento ilman Asynciä niin odottaa datan tallenuksen


                    cmd.Parameters.AddWithValue("ordernumber", orderNumber);


                    cmd.Parameters.AddWithValue("supplier", supplier);


                    cmd.Parameters.AddWithValue("total", total);


                    cmd.Parameters.AddWithValue("purchaser", purchaser);



                    cmd.ExecuteNonQuery();
                }
            }
        }

        static void PrintMenu(string role, User oneUser, Purchaser onePurchaser, ARSpecialist oneARSpecialist, Admin oneAdmin)
        {
            if (role == "Purchaser")
            {
                onePurchaser.GetPurchaserMenu();
            }
            else if (role == "ARSpecialist")
            {
                oneARSpecialist.GetARSPecialistMenu();
            }
            else if (role == "Admin")
            {
                oneAdmin.GetAdminMenu();
            }
        }

        public static void SearchInvoices(List<Invoice> invoices)
        {
            Console.WriteLine("Give ordernumber");
            string orderNumber = Console.ReadLine();
            Console.WriteLine("Give supplier");
            string supplier = Console.ReadLine();
            int invoicefound = 0;

            foreach (Invoice item in invoices)
            {
                if (orderNumber == item.GetOrderNumber() && supplier == item.GetSupplier())
                {
                    Console.WriteLine("Inspector is " + item.GetInspector());
                    Console.WriteLine("Total is " + item.GetTotal());
                    if (item.GetInspectedStatus())
                    {
                        Console.WriteLine("Inspection status is accepted");
                    }
                    else
                    {
                        Console.WriteLine("Inspection status is unaccepted or rejected");
                    }

                    invoicefound++;
                }
            }
            if (invoicefound == 0)
            {
                Console.WriteLine("No invoices found. Want to print all invoices? y or n");
                try
                {
                    char response = char.Parse(Console.ReadLine());
                    if (response == 'y')
                    {
                        foreach (Invoice item in invoices)
                        {
                            Console.WriteLine($"Ordernumber is {item.GetOrderNumber()} and supplier is {item.GetSupplier()}");
                            Console.WriteLine("Inspector is " + item.GetInspector());
                            Console.WriteLine("Total is " + item.GetTotal());
                            if (item.GetInspectedStatus())
                            {
                                Console.WriteLine("Inspection status is accepted");
                            }
                            else
                            {
                                Console.WriteLine("Inspection status is unaccepted or rejected");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Returning to menu");
                    }
                }
                catch
                {
                    Console.WriteLine("Response needs to be either y or n. Returning to menu.");
                }
            }
        }

        public static void SearchOrders(List<Order> orders)
        {
            Console.WriteLine("Give ordernumber");
            string orderNumber = Console.ReadLine();
            Console.WriteLine("Give supplier");
            string supplier = Console.ReadLine();
            int orderfound = 0;

            foreach (Order item in orders)
            {
                if (orderNumber == item.GetOrderNumber() && supplier == item.GetSupplier())
                {
                    Console.WriteLine($"Orderer is {item._purchaser} and total is {item.GetTotal()}");
                    orderfound++;
                }
            }
            if (orderfound == 0)
            {
                Console.WriteLine("No orders found. Want to print all invoices? y or n");
                try
                {
                    char response = char.Parse(Console.ReadLine());
                    if (response == 'y')
                    {
                        foreach (Order item in orders)
                        {
                            Console.WriteLine($"Orderer is {item._purchaser} and total is {item.GetTotal()}");
                            Console.WriteLine($"Ordernumber is {item.GetOrderNumber()} and supplier is {item.GetSupplier()}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Returning to menu");
                    }
                }
                catch
                {
                    Console.WriteLine("Response needs to be either y or n. Returning to menu.");
                }
            }

        }

        static void Main(string[] args)
        {
            //Creating here objects of User parent class and all the child classes so the appropriate methods can be called via that one object
            User oneUser = new User();
            Purchaser onePurchaser = new Purchaser();
            ARSpecialist oneARSpecialist = new ARSpecialist();
            Admin oneAdmin = new Admin();

            //Here the program starts asking for user information and fetching role
            string name, role;
            role = "Null";
            Console.WriteLine("Give name");
            name = Console.ReadLine();
            if (oneUser.WorkerRole(name) == "") // käyttäjää ei löytynyt
            {
                Console.WriteLine("User not found.");
                Console.WriteLine("Tähän jotain hienoja lisäohjeita käyttäjälle");
                
            }
            Console.WriteLine(oneUser.WorkerRole(name));
            role = oneUser.WorkerRole(name);


            //Here is all the hardcoded data for documents

            string orderOrInvoice;
            string orderNumber;
            string supplier;
            string purchaser;
            double total;

            string adder;

            //List for orders 
            List<Order> orders = new List<Order>();
            //Fetching the data from database to list 

            var connString = "Host=localhost;Username=postgres;Password=Grespost99;Database=project";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open(); // Here we open connection
                             // Here we define our SQL query

                using (var cmd = new NpgsqlCommand("SELECT * FROM orders", conn))
                //Luodaan reader muuttuja, johon me luetaan kyselyn tulokset
                //Readerissa on kaikki ja niitä voidaan hakea Readilla
                using (var reader = cmd.ExecuteReader())
                    // Let's loop through all fetched rows
                    while (reader.Read())
                    // Let's get the string value in the field 1
                    {
                        //Data needs to be added for the class in following order (string purchaser, string orderNumber, string supplier, double total)
                        orders.Add(new Order(reader.GetString(4), reader.GetString(1), reader.GetString(2), reader.GetDouble(3)));
                    }
            }





            //List for invoices and hardcoded invoices
            List<Invoice> invoices = new List<Invoice>();
            //The data needs to be given in order string orderNumber, string supplier, double total, string duedate, string adder
            DateTime duedate = new DateTime(2019, 11, 21);
            invoices.Add(new Invoice("123", "Kesko", 13, duedate, "Maija"));



            //Setting inspector. Data needed is string ordernumber, string supplier, List<Order> orders
            invoices[0].SetInspector("123", "Kesko", orders);


            //HARDCODED DATA ENDS HERE AND PROGRAM WITH MENU ETC STARTS!!!!!

            if (role == "Purchaser")
            {
                onePurchaser.PrintWelcomeMessage(invoices, name);
            }
            else if (role == "ARSpecialist")
            {
                oneARSpecialist.PrintWelcomeMessage(invoices, name);
            }
            else if (role == "Admin")
            {
                oneAdmin.PrintWelcomeMessage(invoices, name);
            }


            PrintMenu(role, oneUser, onePurchaser, oneARSpecialist, oneAdmin);



            Boolean continuous = true;

            while (continuous)
            {
                Console.WriteLine("Give command");
                try
                {
                    char command = char.Parse(Console.ReadLine());


                    switch (command)
                    {
                        case 's': //Searching for the documents
                            Console.WriteLine("Order or Invoice?");
                            orderOrInvoice = Console.ReadLine();
                            while (orderOrInvoice != "Order" && orderOrInvoice != "Invoice")
                            {
                                Console.WriteLine("Input must be either Order or Invoice. Try again.");
                                orderOrInvoice = Console.ReadLine();
                            }
                            if (orderOrInvoice == "Order")
                            {
                                SearchOrders(orders);

                            }
                            else if (orderOrInvoice == "Invoice")
                            {
                                SearchInvoices(invoices);
                            }
                            else
                            {
                                Console.WriteLine("Error in choices, it must be either Invoice or Order");
                            }
                            break;

                        case 'n'://Add new document
                            try
                            {
                                Console.WriteLine("Order or Invoice?");
                                orderOrInvoice = Console.ReadLine();
                                while (orderOrInvoice != "Order" && orderOrInvoice != "Invoice")
                                {
                                    Console.WriteLine("Input must be either Order or Invoice. Try again.");
                                    orderOrInvoice = Console.ReadLine();
                                }
                                Console.WriteLine("Give ordernumber");
                                orderNumber = Console.ReadLine();
                                Console.WriteLine("Give supplier");
                                supplier = Console.ReadLine();
                                Console.WriteLine("Give total");
                                total = double.Parse(Console.ReadLine());

                                if (orderOrInvoice == "Order")
                                {
                                    purchaser = name;
                                    OrderInput(purchaser, orderNumber, supplier, total);
                                    orders.Add(new Order(purchaser, orderNumber, supplier, total));
                                    Console.WriteLine("Order was added");
                                }
                                else if (orderOrInvoice == "Invoice")
                                {
                                    Console.WriteLine("Give duedate in form YYYY, MM, DD");
                                    duedate = DateTime.Parse(Console.ReadLine());
                                    adder = name;
                                    int orderToConnect = 0;
                                    foreach (Order item in orders)
                                    {
                                        if (item.GetOrderNumber() == orderNumber && item.GetSupplier() == supplier)
                                        {
                                            invoices.Add(new Invoice(orderNumber, supplier, total, duedate, adder));
                                            orderToConnect++;
                                        }
                                    }
                                    if (orderToConnect > 0)
                                    {
                                        foreach (var item in invoices)
                                        {
                                            if (item.GetOrderNumber() == orderNumber && item.GetSupplier() == supplier)
                                            {
                                                item.SetInspector(orderNumber, supplier, orders);
                                            }
                                        }

                                        Console.WriteLine("Invoice was added");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No matching order found for invoice so not able to add invoice.");
                                    }


                                }
                                else
                                {
                                    Console.WriteLine("Error in choices, it must be either Invoice or Order");
                                }
                            }


                            catch (Exception ex)
                            {
                                Console.WriteLine("Please check data you've inputted to total. It must be XX,xx");
                            }

                            break;

                        case 'i'://Inspecting invoice. Needed data is string inspectionResult
                            Console.WriteLine("Give ordernumber");
                            orderNumber = Console.ReadLine();
                            Console.WriteLine("Give supplier");
                            supplier = Console.ReadLine();
                            string inspection = "null";
                            Console.WriteLine("Inspect the invoice and order. Do you Accept or Reject the invoice? Respond Accept or Reject");
                            inspection = Console.ReadLine();
                            while (inspection != "Accept" && inspection != "Reject" && inspection != "Null")
                            {
                                Console.WriteLine("Answer must be either Accept or Reject. If you don't want respond give Null");
                                inspection = Console.ReadLine();

                            }

                            foreach (var item in invoices)
                            {
                                if (item.GetOrderNumber() == orderNumber && item.GetSupplier() == supplier)
                                {
                                    item.SetInspectedStatus(inspection);
                                }
                            }



                            break;

                        case 'a': //Add new user
                            oneUser.CreateNewWorker();
                            break;



                        case 'm': //Bring menu
                            PrintMenu(role, oneUser, onePurchaser, oneARSpecialist, oneAdmin);
                            break;

                        case 'q': //Quit program
                            continuous = false;
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("The input needs to be a character from presented menu");
                }
            }



        }
    }
}
