﻿namespace Goldan_Maria_EB_lab2.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int BookID { get; set; }
        public Customer Customer { get; set; }
        public Book Book { get; set; }
    }
}
