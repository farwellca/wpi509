using MySql.Data.MySqlClient;
using System.Data;

namespace con
{
    class Program
    {
        static void Main(string[] args)
        {
            var dtDelta = new DataTable();
            var dtSouthwest = new DataTable();
            string connectionString = "server=host.docker.internal;port=3333;uid=root;pwd=a;database=FlightData";
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (var da = new MySqlDataAdapter(@"select * from deltas limit 1", connection))
                {
                    da.Fill(dtDelta);
                }

                using (var da = new MySqlDataAdapter(@"select * from southwests limit 1", connection))
                {
                    da.Fill(dtSouthwest);
                }
            }

            Console.WriteLine("select * from deltas limit 1 returns:");
            Console.WriteLine((DateTime)dtDelta.Rows[0]["DepartDateTime"] + " " + (DateTime)dtDelta.Rows[0]["ArriveDateTime"] + " "
                + (string)dtDelta.Rows[0]["DepartAirport"] + " " + (string)dtDelta.Rows[0]["ArriveAirport"] + " " + (string)dtDelta.Rows[0]["FlightNumber"] + "\n");

            Console.WriteLine("select * from southwests limit 1 returns:");
            Console.WriteLine((DateTime)dtSouthwest.Rows[0]["DepartDateTime"] + " " + (DateTime)dtSouthwest.Rows[0]["ArriveDateTime"] + " "
                + (string)dtSouthwest.Rows[0]["DepartAirport"] + " " + (string)dtSouthwest.Rows[0]["ArriveAirport"] + " " + (string)dtSouthwest.Rows[0]["FlightNumber"] + "\n");
        }
    }
}