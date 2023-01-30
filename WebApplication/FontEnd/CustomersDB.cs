using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.FontEnd
{
    public class CustomersDB
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
        public List<Users> ListCusAll()
        {
            List<Users> lst = new List<Users>();
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectCustomerstabledata", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Users
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        username = rdr["user"].ToString().Replace(" ", ""),
                        password = rdr["pass"].ToString().Replace(" ", ""),
                    });
                }
                return lst;
            }
        }
    }
}