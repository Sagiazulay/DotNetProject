using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetProject
{
    class Administrator : IPOCO, IUser
    {
        public int ID { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Level { get; set; }
        public int User_Id { get; set; }

        public Administrator()
        {

        }

        public Administrator(string first_Name, string last_Name, int level, int user_Id)
        {
            First_Name = first_Name;
            Last_Name = last_Name;
            Level = level;
            User_Id = user_Id;
        }

        public override bool Equals(object obj)
        {
            return obj is Administrator administrator &&
                   ID == administrator.ID &&
                   First_Name == administrator.First_Name &&
                   Last_Name == administrator.Last_Name &&
                   Level == administrator.Level &&
                   User_Id == administrator.User_Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, First_Name, Last_Name, Level, User_Id);
        }
        public static bool operator ==(Administrator a1, Administrator a2)
        {
            return a1.ID == a2.ID ? true : false;
        }
        public static bool operator !=(Administrator a1, Administrator a2)
        {
            return !(a1 == a2);
        }
    }
}
