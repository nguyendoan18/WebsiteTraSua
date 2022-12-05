using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string codeproducts { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public string image { get; set; }
    }
}