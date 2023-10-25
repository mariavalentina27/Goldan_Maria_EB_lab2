using System.ComponentModel.DataAnnotations;

namespace Goldan_Maria_EB_lab2.Models.LibraryViewModel
{
    public class OrderGroup
    {
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int BookCount { get; set; }
    }
}
