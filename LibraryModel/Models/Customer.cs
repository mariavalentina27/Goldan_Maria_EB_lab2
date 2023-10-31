﻿namespace Goldan_Maria_EB_lab2.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public int CityID { get; set; }
        public City? City { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Order>? Orders { get; set; }
    }
}