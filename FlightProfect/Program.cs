﻿using DotNetProject;
using System;

namespace FlightProfect
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string conn = "Host = localhost; Username = postgres; Password = admin; Database = postgres";
                //CountryDAOPGSQL q = new CountryDAOPGSQL("Host = localhost; Username = postgres; Password = admin; Database = postgres");
                //CountryDAOPGSQL.a_sp_insert_country(conn, "Levanon");
                //CountryDAOPGSQL.a_sp_update_country(conn, 6, "Lov");
                //CountryDAOPGSQL.a_sp_get_all_countries(conn);
                //CountryDAOPGSQL.a_sp_get_country_by_id(conn, 6);
                //AirlineCompanyDAO.a_sp_insert_airline_company(conn, "ZAP", 2, 9);  NOT WORKING
                //TicketDAO.a_sp_insert_ticket(conn, 2, 4);
                //TicketDAO.a_sp_get_ticket_by_id(conn, 1);
                TicketDAO.a_sp_get_all_tickets(conn);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Problema! : {ex}");
            }
        }
    }
}
