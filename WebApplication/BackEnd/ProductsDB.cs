using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.BackEnd
{
    public class ProductsDB
    {
        public List<Products> ListAll()
        {
            List<Products> lst = new List<Products>();
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectProcutstabledata", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Products
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        codeproducts = rdr["codeproducts"].ToString().Trim(),
                        title = rdr["title"].ToString().Trim(),
                        description = rdr["description"].ToString().Trim(),
                        price = Convert.ToInt64(rdr["price"]),
                        image = rdr["image"].ToString(),
                    });
                }
                return lst;
            }
        }

        public int Add(Users user)
        {
            int i;
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AdminDBInsert", con);
                com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@Id", user.Id);
                com.Parameters.AddWithValue("@username", user.username);
                com.Parameters.AddWithValue("@password", user.password);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public int Update(Users user)
        {
            int i;
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("AdminDBUpdate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", user.Id);
                com.Parameters.AddWithValue("@username", user.username);
                com.Parameters.AddWithValue("@password", user.password);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
        public int Delete(int Id)
        {
            int i;
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("ProDBDelete", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", Id);
                i = com.ExecuteNonQuery();
            }
            return i;
        }
    }
}