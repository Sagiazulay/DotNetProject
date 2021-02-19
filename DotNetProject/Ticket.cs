using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    public class Ticket : IPOCO
    {
        public long ID { get; set; }
        public long Flight_Id { get; set; }
        public long Customer_Id { get; set; }

        public Ticket()
        {

        }

        public Ticket(long id, long flight_Id, long customer_Id)
        {
            ID = id;
            Flight_Id = flight_Id;
            Customer_Id = customer_Id;
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as Ticket).ID;
        }

        public override int GetHashCode()
        {
            return (int)this.ID;
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
