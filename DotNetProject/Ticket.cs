using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    class Ticket : IPOCO
    {
        public int ID { get; set; }
        public int Flight_Id { get; set; }
        public int Customer_Id { get; set; }

        public Ticket()
        {

        }

        public Ticket(int flight_Id, int customer_Id)
        {
            Flight_Id = flight_Id;
            Customer_Id = customer_Id;
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as Ticket).ID;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
        public static bool operator ==(Ticket t1, Ticket t2)
        {
            return t1.ID == t2.ID ? true : false;
        }
        public static bool operator !=(Ticket t1, Ticket t2)
        {
            return !(t1 == t2);
        }
    }
}
