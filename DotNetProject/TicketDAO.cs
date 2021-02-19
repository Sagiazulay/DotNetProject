using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    public class TicketDAO
    {
        private string m_conn = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
        private static readonly log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public TicketDAO(string conn)
        {
            m_conn = conn;
        }
        static bool TestDbConnection(string conn)
        {
            try
            {
                using (var my_conn = new NpgsqlConnection(conn))
                {
                    my_conn.Open();
                    my_logger.Debug("Test connection secceeded!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                my_logger.Debug("Test connection Failed!");
                return false;
            }
        }
        public static void a_sp_insert_ticket(string conn_string, int flight_id, int customer_id)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "sp_insert_ticket1";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("flight_id", flight_id);
                command.Parameters.AddWithValue("customer_id", customer_id);
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                //long new_id = 0;
                //while (reader.Read())
                //{
                //    new_id = (int)reader["id"];
                //}
                //my_logger.Info($"New Ticket Number:{new_id} has inserted into the DB");
            }
        }
        public static Ticket a_sp_get_ticket_by_id(string conn_string, long id_num)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"select * from tickets where id = {id_num};";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.Text;
                //command.Parameters.AddWithValue("_id", id_num);
                var reader = command.ExecuteReader();
                Ticket selected = new Ticket();
                while (reader.Read())
                {
                    long id = (long)reader["id"];
                    long Flight_Id = (long)reader["flight_Id"];
                    long Customer_Id = (long)reader["customer_id"];

                    selected = new Ticket(id = (long)reader["id"], Flight_Id = (long)reader["flight_Id"], Customer_Id = (long)reader["customer_id"]);

                }
                return selected;
            }
        }
        public static void a_sp_get_all_tickets(string conn_string)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "SELECT * FROM tickets";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.Text;
                List<Ticket> countries = new List<Ticket>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    long id = (long)reader["id"];
                    long Flight_Id = (long)reader["flight_Id"];
                    long Customer_Id = (long)reader["customer_id"];

                    countries.Add(new Ticket(id = (long)reader["id"], Flight_Id = (long)reader["flight_Id"], Customer_Id = (long)reader["customer_id"]));
                }
            }
        }
    }
}
