﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication.Models;
using System.Reflection;
using WebApplication.BackEnd;

namespace WebApplication.FontEnd
{
    public class ProductsDB
    {//declare connection string  

        //Return list of all Employees  
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
                        codeproducts = rdr["codeproducts"].ToString(),
                        title = rdr["title"].ToString(),
                        description = rdr["description"].ToString(),
                        price = Convert.ToInt64(rdr["price"]),
                        image = rdr["image"].ToString(),
                    });
                }
                return lst;
            }
        }

        public List<Products> SearchProducts(string search)
        {
            List<Products> lst = new List<Products>();
            using (SqlConnection con = new SqlConnection(Connection.strConnect))
            {
                con.Open();
                string sql = $@"select pro.Id, pro.codeproducts, pro.title, pro.description, pro.price, pro.image, cat.codecategory as category 
        from products pro INNER JOIN categorys cat ON pro.category = cat.codecategory
        where pro.title Like N'%{search}%'";
                SqlCommand com = new SqlCommand(sql, con);
                //com.CommandType = CommandType.StoredProcedure;
                //com.Parameters.AddWithValue("@title", search);
                SqlDataReader rdr = com.ExecuteReader();
                while (rdr.Read())
                {
                    lst.Add(new Products
                    {
                        Id = Convert.ToInt32(rdr["Id"]),
                        codeproducts = rdr["codeproducts"].ToString(),
                        title = rdr["title"].ToString(),
                        description = rdr["description"].ToString(),
                        price = Convert.ToInt64(rdr["price"]),
                        image = rdr["image"].ToString(),
                    });
                }
                return lst;
            }
        }
    }
}