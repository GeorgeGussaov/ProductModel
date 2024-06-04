using System;
using System.Collections.Generic;
using System.Text;

namespace OnLineShop.DB.Models
{
    public class OrderDB
    {
        public Guid Id { get; set; }
        public string User { get; set; }
        public CartDB Cart { get; set; }
    }
}
