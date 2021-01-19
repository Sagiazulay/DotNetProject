using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    class Flight : IPOCO 
    {
        public int ID { get; set; }
        public int Airline_Company_Id { get; set; }
        public int Origin_Country_Id { get; set; }
        public int Destination_Country_Id { get; set; }
        public DateTime Departure_Time { get; set; }
        public DateTime Landing_Time { get; set; }
        public int Remaining_Tickets { get; set; }

        public Flight()
        {

        }
        public Flight(int airline_Company_Id, int origin_Country_Id, int destination_Country_Id, DateTime departure_Time, DateTime landing_Time, int remaining_Tickets)
        {
            Airline_Company_Id = airline_Company_Id;
            Origin_Country_Id = origin_Country_Id;
            Destination_Country_Id = destination_Country_Id;
            Departure_Time = departure_Time;
            Landing_Time = landing_Time;
            Remaining_Tickets = remaining_Tickets;
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as Flight).ID;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
        public static bool operator ==(Flight f1, Flight f2)
        {
            return f1.ID == f2.ID ? true : false;
        }
        public static bool operator !=(Flight f1, Flight f2)
        {
            return !(f1 == f2);
        }
    }
}
