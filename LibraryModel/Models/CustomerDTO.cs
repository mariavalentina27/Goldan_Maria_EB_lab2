using Goldan_Maria_EB_lab2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModel.Models
{
    public class CustomerDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DisplayName("City")]
        public string CityName { get; set; }
        public string Adress { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
