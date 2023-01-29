using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Null_Super_Shop_A_.Data_Access_Layer.Entities;

namespace Null_Super_Shop_A_.Data_Access_Layer
{
    class LoginDataAccess:DataAccess
    {
        public int UserLoginValidation(User user)
        {
            string sql = "SELECT * FROM Users WHERE Username='" + user.Username + "' AND Password='" + user.Password + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["UserType"]); 
            }
            return -1;
        }
    }
}
