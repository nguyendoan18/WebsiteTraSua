using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.FontEnd
{
    public class ProductsDB
    {//declare connection string  
        public static string cs = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\CodeUpdate\WebsiteBanTraSua\WebApplication\WebApplication\App_Data\DBWebTraSua.mdf;Integrated Security=True";

        //Return list of all Employees  
        public List<Products> ListAll()
        {
            List<Products> lst = new List<Products>();
            using (SqlConnection con = new SqlConnection(cs))
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
    }
}