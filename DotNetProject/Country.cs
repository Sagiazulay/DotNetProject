using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    public class Country : IPOCO
    {//a_sp_insert_country
        public int ID { get; set; }
        public string Name { get; set; }

        public Country()
        {

        }

        public Country(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as Country).ID;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
        public static bool operator ==(Country c1, Country c2)
        {
            return c1.ID == c2.ID ? true : false;
        }
        public static bool operator !=(Country c1, Country c2)
        {
            return !(c1 == c2);
        }
    }
}
