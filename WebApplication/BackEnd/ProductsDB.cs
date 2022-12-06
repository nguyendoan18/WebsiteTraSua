using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication.Models;
using System.Web.DynamicData;

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
                        category = rdr["category"].ToString().Trim(),
                    });
                }
                return lst;
            }
        }
        public List<Categorys> ListCategory()
        {
            List<Categorys> lst = new List<Categorys>();
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {
                con.Open();
                SqlCommand com = new SqlCommand("SelectCategorystabledata", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Categorys
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        codecategory = rdr["codecategory"].ToString().Trim(),
                        title = rdr["title"].ToString().Trim(),
                        description = rdr["description"].ToString().Trim(),
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
        public int Update(Products product)
        {
            int i;
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {

                con.Open();
                SqlCommand com = new SqlCommand("ProUpdate", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id", product.Id);
                com.Parameters.AddWithValue("@title", product.title);
                com.Parameters.AddWithValue("@description", product.description);
                com.Parameters.AddWithValue("@price", product.price);
                com.Parameters.AddWithValue("@image", product.image);
                com.Parameters.AddWithValue("@category", product.category);

                if (product.image == "")
                {
                    com.Parameters.AddWithValue("@Action", "NoImage");
                }
                else
                {
                    com.Parameters.AddWithValue("@Action", "YesImage");
                }
                i = com.ExecuteNonQuery();
                return i;

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