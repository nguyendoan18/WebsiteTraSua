using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Carts
    {
        public int Id_cart { get; set; }
        public string Id_order { get; set; }
        public string Id_product { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
    }
}