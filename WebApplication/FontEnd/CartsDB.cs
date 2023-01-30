using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.FontEnd
{
    public class CartsDB
    {
        public int Add(Users user)
        {
            int i;
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("CustomersDBInsert", con);
                com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@Id", user.Id);
                com.Parameters.AddWithValue("@username", user.username);
                com.Parameters.AddWithValue("@password", user.password);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}