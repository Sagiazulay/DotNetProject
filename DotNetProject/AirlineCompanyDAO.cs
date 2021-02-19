using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    public class AirlineCompanyDAO
    {
        private string m_conn = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
        private static readonly log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public AirlineCompanyDAO(string conn)
        {
            conn = m_conn;
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
        public static void a_sp_insert_airline_company(string conn_string, string name, long country_Id, long user_Id)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "sp_insert_airline_company";
                //string sp_name = $"INSERT INTO airline_companies (name, country_id, user_id) VALUES ('{name}', {country_Id}, {user_Id});";


                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //string name, int country_Id, int user_Id
                command.Parameters.AddWithValue("name", name);
                command.Parameters.AddWithValue("country_Id", country_Id);
                command.Parameters.AddWithValue("user_Id", user_Id);
                command.ExecuteNonQuery();
                my_logger.Info($"Airline Company {name} has inserted into the DB");
            }
        }
    }
}
