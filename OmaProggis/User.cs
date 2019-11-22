using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Inheritance
{
    class User
    {

        public void GetBasicMenu()
        {
            Console.WriteLine("\n\nChoose from the following:\n\n");
            Console.WriteLine("[q] Quit\n");
            Console.WriteLine("[m] Menu\n");
            Console.WriteLine("[s] Search for documents\n");


        }

        public string WorkerRole(string name)
        {
            try
            {

                var connString = "Host=localhost;Username=postgres;Password=Grespost99;Database=project";
                using (var conn = new NpgsqlConnection(connString))
                {
                    conn.Open(); // Here we open connection
                                 // Here we define our SQL query
                                 //Luodaan kysely olio
                    using (var cmd = new NpgsqlCommand("SELECT * FROM worker", conn))
                    //Luodaan reader muuttuja, johon me luetaan kyselyn tulokset
                    //Readerissa on kaikki ja niitä voidaan hakea Readilla
                    using (var reader = cmd.ExecuteReader())
                        // Let's loop through all fetched rows
                        while (reader.Read())
                        // Let's get the string value in the field 1
                        {

                            if (name == reader.GetString(1))
                            {
                                return reader.GetString(2);
                            }
                        }

                    return "User not found";

                }
            }
            catch
            {
                return "User nor found";
            }
        }

        public int workerID()
        {
            int workernumber = 0;
            var connString = "Host=localhost;Username=postgres;Password=Grespost99;Database=project";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open(); // Here we open connection
                             // Here we define our SQL query
                             //Luodaan kysely olio
                using (var cmd = new NpgsqlCommand("SELECT * FROM worker", conn))
                //Luodaan reader muuttuja, johon me luetaan kyselyn tulokset
                //Readerissa on kaikki ja niitä voidaan hakea Readilla
                using (var reader = cmd.ExecuteReader())
                    // Let's loop through all fetched rows
                    while (reader.Read())
                        // Let's get the string value in the field 1
                        workernumber = reader.GetInt32(0);
                return workernumber;

            }

        }

        public void CreateNewWorker()
        {
            var connString = "Host=localhost;Username=postgres;Password=Grespost99;Database=project";
            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open(); // Here we open connection
                             // Here we define our SQL query
                using (var cmd = new NpgsqlCommand("INSERT INTO worker VALUES (default, @name, @role);", conn))
                {
                    //ExecuteNonQueryAsync versio ei jää odottamaan, että datan tallennus tietokannassa on valmis
                    //komento ilman Asynciä niin odottaa datan tallenuksen

                    Console.WriteLine("Give username");
                    string name = Console.ReadLine();
                    cmd.Parameters.AddWithValue("name", name);
                    Console.WriteLine("Give role Purchaser, ARSpecialist or Admin");
                    string role = Console.ReadLine();
                    cmd.Parameters.AddWithValue("role", role);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        
    }
}
