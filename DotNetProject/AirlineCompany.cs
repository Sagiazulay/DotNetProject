using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    class AirlineCompany : IPOCO , IUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Country_Id { get; set; }
        public int User_Id { get; set; }

        public AirlineCompany()
        {

        }

        public AirlineCompany(string name, int country_Id, int user_Id)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Country_Id = country_Id;
            User_Id = user_Id;
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as AirlineCompany).ID;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        public static bool operator ==(AirlineCompany f1, AirlineCompany f2)
        {
            return f1.ID == f2.ID ? true : false;
        }
        public static bool operator !=(AirlineCompany f1, AirlineCompany f2)
        {
            return !(f1 == f2);
        }
    }
}
