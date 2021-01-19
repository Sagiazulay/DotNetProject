using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DotNetProject
{
    public class CountryDAOPGSQL
    {
        private string m_conn = "Host=localhost;Username=postgres;Password=admin;Database=postgres";
        private static readonly log4net.ILog my_logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CountryDAOPGSQL(string conn)
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
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private static void a_sp_insert_country(string conn_string)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "a_sp_insert_country";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                List<Country> countries = new List<Country>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string Name = (string)reader["name"];

                    countries.Add(new Country(id = (int)reader["id"], Name = (string)reader["Name"]));
                }
                
            }
        }
        private static void a_sp_update_country(string conn_string, int id, string new_name)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "a_sp_update_country";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var reader = command.ExecuteReader();
     

            }
        }
    }
}
