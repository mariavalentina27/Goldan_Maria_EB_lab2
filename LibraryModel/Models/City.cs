namespace Goldan_Maria_EB_lab2.Models
{
    public class City
    {
        public int ID {  get; set; }
        public string CityName { get; set; }
        public ICollection<Customer>? Customers { get; set; }
    }
}
