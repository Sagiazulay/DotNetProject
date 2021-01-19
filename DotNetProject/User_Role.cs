using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    class User_Role
    {
        public int ID { get; set; }
        public string Role_Name { get; set; }

        public User_Role()
        {

        }

        public User_Role(string role_Name)
        {
            Role_Name = role_Name;
        }

        public override bool Equals(object obj)
        {
            return obj is User_Role role &&
                   ID == role.ID &&
                   Role_Name == role.Role_Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Role_Name);
        }
        public static bool operator ==(User_Role u1, User_Role u2)
        {
            return u1.ID == u2.ID ? true : false;
        }
        public static bool operator !=(User_Role u1, User_Role u2)
        {
            return !(u1 == u2);
        }
    }
}
