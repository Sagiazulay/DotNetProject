using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    public class User : IPOCO
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int User_Role { get; set; }

        public User()
        {

        }

        public User(string username, string password, string email, int user_Role)
        {
            Username = username;
            Password = password;
            Email = email;
            User_Role = user_Role;
        }

        public override bool Equals(object obj)
        {
            return this.ID == (obj as User).ID;
        }

        public override int GetHashCode()
        {
            return this.ID;
        }
        public static bool operator ==(User u1, User u2)
        {
            return u1.ID == u2.ID ? true : false;
        }
        public static bool operator !=(User u1, User u2)
        {
            return !(u1 == u2);
        }
    }
}
