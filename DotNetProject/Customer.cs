using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    class Customer : IPOCO , IUser
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Phone_No { get; set; }
        public string Credit_Card_No { get; set; }
        public int User_Id { get; set; }

        public Customer()
        {

        }

        public Customer(string first_Name, string last_Name, string address, string phone_No, string credit_Card_No, int user_Id)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Address = address;
            Phone_No = phone_No;
            Credit_Card_No = credit_Card_No;
            User_Id = user_Id;
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as Customer).ID;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public static bool operator ==(Customer c1, Customer c2)
        {
            return c1.ID == c2.ID ? true : false;
        }
        public static bool operator !=(Customer c1, Customer c2)
        {
            return !(c1 == c2);
        }
    }
}
