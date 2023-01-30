using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Carts
    {
        public int Id { get; set; }
        public string customer { get; set; }
        public string category { get; set; }
        public int quantity { get; set; }
        public DateTime datetime { get; set; }
    }
}