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
        public static void a_sp_insert_country(string conn_string, string country_name)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "a_sp_insert_country";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.AddWithValue("name", country_name);
                command.ExecuteNonQuery();
                my_logger.Info($"Country {country_name} has inserted into the DB");
            }
        }
        public static void a_sp_update_country(string conn_string, long id, string new_name)
        {
                NpgsqlConnection conn = new NpgsqlConnection(conn_string);
                conn.Open();

                NpgsqlCommand cmdd = new NpgsqlCommand($"call a_sp_update_country({id},'{new_name}')", conn);
                cmdd.Connection = conn;
                cmdd.CommandType = CommandType.Text;            
                cmdd.ExecuteNonQuery();
                conn.Close();
            my_logger.Info($"Country ID {id} has changed to a new name : '{new_name}'");
        }
        public static void a_sp_get_all_countries(string conn_string)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = "SELECT * FROM countries";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.Text;
                List<Country> countries = new List<Country>();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string Name = (string)reader["name"];

                    countries.Add(new Country(id = (int)reader["id"], Name = (string)reader["name"]));
                }
            }
        }
        public static Country a_sp_get_country_by_id(string conn_string, long id_num)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"select * from countries where id = {id_num};";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.Text;
                //command.Parameters.AddWithValue("_id", id_num);
                var reader = command.ExecuteReader();
                Country selected = new Country();
                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string Name = (string)reader["name"];

                    selected = (new Country(id = (int)reader["id"], Name = (string)reader["name"]));

                }
                return selected;
            }
        }
        public static void a_sp_delete_country(string conn_string, long id_num)
        {
            using (var conn = new NpgsqlConnection(conn_string))
            {
                conn.Open();
                string sp_name = $"delete from countries where id = {id_num};";

                NpgsqlCommand command = new NpgsqlCommand(sp_name, conn);
                command.CommandType = System.Data.CommandType.Text;
                var reader = command.ExecuteReader();
                my_logger.Info($"Country ID [{id_num}] had deleted from DB");
            }
        }
    }
}
