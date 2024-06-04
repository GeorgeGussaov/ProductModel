using Microsoft.VisualBasic;
using OnLineShop.DB.Models;
using System;

namespace ProductModel.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public Cart Cart { get; set; }
    }
}
